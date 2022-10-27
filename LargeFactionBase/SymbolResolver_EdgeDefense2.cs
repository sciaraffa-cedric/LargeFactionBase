﻿using System;
using UnityEngine;
using Verse;
using Verse.AI.Group;
using RimWorld.BaseGen;
using RimWorld;

namespace LargeFactionBase
{
    public class SymbolResolver_EdgeDefense2 : SymbolResolver
    {
        private const int DefaultCellsPerTurret = 20;

        private const int DefaultCellsPerMortar = 200;

        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;
            Faction faction = rp.faction ?? Find.FactionManager.RandomEnemyFaction(false, false, true, TechLevel.Undefined);
            int? edgeDefenseGuardsCount = rp.edgeDefenseGuardsCount;
            int num = (!edgeDefenseGuardsCount.HasValue) ? 0 : edgeDefenseGuardsCount.Value;
            int width;
            if (rp.edgeDefenseWidth.HasValue)
            {
                width = rp.edgeDefenseWidth.Value;
            }
            else if (rp.edgeDefenseMortarsCount.HasValue && rp.edgeDefenseMortarsCount.Value > 0)
            {
                width = 4;
            }
            else
            {
                width = ((!Rand.Bool) ? 4 : 2);
            }
            width = Mathf.Clamp(width, 1, Mathf.Min(rp.rect.Width, rp.rect.Height) / 2);
            int num2;
            int num3;
            bool flag;
            bool flag2;
            bool flag3;
            switch (width)
            {
                case 1:
                    {
                        int? edgeDefenseTurretsCount = rp.edgeDefenseTurretsCount;
                        num2 = ((!edgeDefenseTurretsCount.HasValue) ? 0 : edgeDefenseTurretsCount.Value);
                        num3 = 0;
                        flag = false;
                        flag2 = true;
                        flag3 = true;
                        break;
                    }
                case 2:
                    {
                        int? edgeDefenseTurretsCount2 = rp.edgeDefenseTurretsCount;
                        num2 = ((!edgeDefenseTurretsCount2.HasValue) ? (rp.rect.EdgeCellsCount / 30) : edgeDefenseTurretsCount2.Value);
                        num3 = 0;
                        flag = false;
                        flag2 = false;
                        flag3 = true;
                        break;
                    }
                case 3:
                    {
                        int? edgeDefenseTurretsCount3 = rp.edgeDefenseTurretsCount;
                        num2 = ((!edgeDefenseTurretsCount3.HasValue) ? (rp.rect.EdgeCellsCount / 30) : edgeDefenseTurretsCount3.Value);
                        int? edgeDefenseMortarsCount = rp.edgeDefenseMortarsCount;
                        num3 = ((!edgeDefenseMortarsCount.HasValue) ? (rp.rect.EdgeCellsCount / 75) : edgeDefenseMortarsCount.Value);
                        flag = (num3 == 0);
                        flag2 = false;
                        flag3 = true;
                        break;
                    }
                default:
                    {
                        int? edgeDefenseTurretsCount4 = rp.edgeDefenseTurretsCount;
                        num2 = ((!edgeDefenseTurretsCount4.HasValue) ? (rp.rect.EdgeCellsCount / 30) : edgeDefenseTurretsCount4.Value);
                        int? edgeDefenseMortarsCount2 = rp.edgeDefenseMortarsCount;
                        num3 = ((!edgeDefenseMortarsCount2.HasValue) ? (rp.rect.EdgeCellsCount / 75) : edgeDefenseMortarsCount2.Value);
                        flag = true;
                        flag2 = false;
                        flag3 = false;
                        break;
                    }
            }
            if (faction != null && faction.def.techLevel < TechLevel.Industrial)
            {
                num2 = 0;
                num3 = 0;
            }
            if (num > 0)
            {
                Lord singlePawnLord = rp.singlePawnLord ?? LordMaker.MakeNewLord(faction, new LordJob_DefendBase(faction, rp.rect.CenterCell), map, null);
                for (int i = 0; i < num; i++)
                {
                    //1.0 PawnGenerationRequest value = new PawnGenerationRequest(faction.RandomPawnKind(), faction, PawnGenerationContext.NonPlayer, -1, false, false, false, false, true, true, 1f, false, true, true, false, false, false, false, null, null, null, null, null, null, null, null);

                                        PawnGenerationRequest value = new PawnGenerationRequest(faction.RandomPawnKind(), // KindDef
                    faction, //Faction
                    PawnGenerationContext.NonPlayer,  //Context 
                    -1, //Tile
                    false, //ForceGenerateNewPawn
                    false, //Newborn
                    false, //AllowDead 
                    false, //AllowDowned
                    false, //CanGeneratePawnRelations
                    true, //MustBeCapaleOfViolence 
                    1f, //ColonistRelationChanceFactor
                    true, // ForceAddFreeWarmLayerIfNeeded
                    true, //AllowGay 
                    true, //AllowFood
                    true, //AllowAddiction
                    false, //Inhabitant
                    false, //CertainlyBeenInCryptoSleep
                    false, //ForceRedressWorldPawnIfFormerColonist
                    false, //WorldPawnFactionDoesntMatter
                    0f, //BioCodeWeaponChance
                    0f, //BioCodeApparelChance
                    null, //ExtraPawnForExtraRelationChance 
                    1f, //RelationWithExtraPawn
                    null, //ValidatorPreGear 
                    null, //ValidatorPostGear
                    null, //forcedTraits  
                    null, //ProhibitedTraits
                    null, //minChanceToRedressWorldPawn 
                    null, //FixedBiologicalAge
                    null, //FixedChronologicalAge
                    null, //FixedGender
                    null, //FixedMelanin
                    null, //FixedLastName
                    null, //FixedBirthName
                    null, //FixedTitle
                    null, //FixedIdeo
                    false, //ForceNoIdeo
                    false, //FordeNoBackstory
                    false //ForbidAnyTitle
                    );

                    ResolveParams rp2 = rp;
                    rp2.faction = faction;
                    rp2.singlePawnLord = singlePawnLord;
                    rp2.singlePawnGenerationRequest = new PawnGenerationRequest?(value);
                    rp2.singlePawnSpawnCellExtraPredicate = (rp2.singlePawnSpawnCellExtraPredicate ?? delegate (IntVec3 x)
                    {
                        CellRect cellRect = rp.rect;
                        for (int m = 0; m < width; m++)
                        {
                            if (cellRect.IsOnEdge(x))
                            {
                                return true;
                            }
                            cellRect = cellRect.ContractedBy(1);
                        }
                        return true;
                    });
                    BaseGen.symbolStack.Push("pawn", rp2);
                }
            }
            CellRect rect = rp.rect;
            for (int j = 0; j < width; j++)
            {
                if (j % 2 == 0)
                {
                    ResolveParams rp3 = rp;
                    rp3.faction = faction;
                    rp3.rect = rect;
                    BaseGen.symbolStack.Push("edgeSandbags", rp3);
                    if (!flag)
                    {
                        break;
                    }
                }
                rect = rect.ContractedBy(1);
            }
            CellRect rect2 = (!flag3) ? rp.rect.ContractedBy(1) : rp.rect;
            for (int k = 0; k < num3; k++)
            {
                ResolveParams rp4 = rp;
                rp4.faction = faction;
                rp4.rect = rect2;
                BaseGen.symbolStack.Push("edgeMannedMortar", rp4);
            }
            CellRect rect3 = (!flag2) ? rp.rect.ContractedBy(1) : rp.rect;
            for (int l = 0; l < num2 * 2; l++)
            {
                ResolveParams rp5 = rp;
                rp5.faction = faction;
                rp5.singleThingDef = ThingDefOf.Turret_MiniTurret;

                if (Rand.Chance(0.1f))
                {
                    rp5.singleThingDef = Large_DefOf.Turret_Sniper;
                    //rp5.singleThingDef = Large_DefOf.Turret_Blaster;
                }

                if (Rand.Chance(0.2f))
                {
                    rp5.singleThingDef = Large_DefOf.Turret_Autocannon;
                    //rp5.singleThingDef = Large_DefOf.Turret_Heavy;
                }
                rp5.rect = rect3;
                bool? edgeThingAvoidOtherEdgeThings = rp.edgeThingAvoidOtherEdgeThings;
                rp5.edgeThingAvoidOtherEdgeThings = new bool?(!edgeThingAvoidOtherEdgeThings.HasValue || edgeThingAvoidOtherEdgeThings.Value);
                BaseGen.symbolStack.Push("edgeThing", rp5);
            }
        }
    }
}

