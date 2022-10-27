using System;
using Verse;
using RimWorld;
using LargeFactionBase;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Corpse3 : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            var count = rp.hivesCount ?? Rand.Range(1,3);

            for (int i = 0; i < count; i++)
            {
                //ThingDef singleThingDef = rp.singleThingDef ?? Rand.Element<ThingDef>(ThingDefOf.Bed, ThingDefOf.Bedroll, ThingDefOf.SleepingSpot);

                //PawnKindDef kind = (rp.faction != null && rp.faction.def.techLevel.IsNeolithicOrWorse()) ? (Rand.Chance(0.5f) ? LargeFactionBase.Large_PawnKindDefOf.Tribal_ChiefMelee :

                /*PawnKindDef kind = (rp.faction != null && rp.faction.def.techLevel < TechLevel.Industrial) ? (Rand.Chance(0.5f) ? LargeFactionBase.Large_PawnKindDefOf.Tribal_ChiefMelee :
                LargeFactionBase.Large_PawnKindDefOf.Tribal_HeavyArcher)
                : LargeFactionBase.Large_PawnKindDefOf.Soldier;*/

                PawnKindDef kind = PawnKindDefOf.Slave;
                Faction faction = rp.faction;
                //1.0
                //PawnGenerationRequest request = new PawnGenerationRequest(kind, faction,
                //    PawnGenerationContext.NonPlayer, BaseGen.globalSettings?.map?.Tile ?? Find.CurrentMap.Tile, false, false, false, false, true, true, 1f, false, true, false,
                //    false, false, false, false, null, null, null, null, null, null, null);

                PawnGenerationRequest request = new PawnGenerationRequest(kind, // KindDef
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

                Pawn pawn = PawnGenerator.GeneratePawn(request);

                IntVec3 spawnLoc;
                var map = BaseGen.globalSettings?.map ?? Find.CurrentMap;

                //Pawn pawn2 = PrisonerWillingToJoinQuestUtility.GeneratePrisoner(map.info.Tile, faction);

                CellFinderLoose.TryGetRandomCellWith(x => x.IsValid && rp.rect.Contains(x) && x.GetEdifice(map) == null && x.GetFirstItem(map) == null,
                    map, 100000, out spawnLoc);
                
                GenSpawn.Spawn(pawn, spawnLoc, map);

                if (Rand.Value > 0.25f)
                {
                    HealthUtility.DamageUntilDowned(pawn, false);
                }
                else
                {
                    HealthUtility.DamageLegsUntilIncapableOfMoving(pawn, true);
                }
            }
        }
    }
}