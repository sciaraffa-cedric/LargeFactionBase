using System;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Corpse : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {

            var count = rp.hivesCount ?? Rand.Range(1,3);

            for (int i = 0; i < count; i++)
            {
                //ThingDef singleThingDef = rp.singleThingDef ?? Rand.Element<ThingDef>(ThingDefOf.Bed, ThingDefOf.Bedroll, ThingDefOf.SleepingSpot);
                PawnKindDef kind = (Rand.Value > 0.7f) ? ((Rand.Value > 0.6f) ? PawnKindDefOf.AncientSoldier :
                    PawnKindDefOf.WellEquippedTraveler) : PawnKindDefOf.Slave;

                Faction faction = rp.faction;
                //1.0 PawnGenerationRequest request = new PawnGenerationRequest(kind, faction, PawnGenerationContext.NonPlayer, BaseGen.globalSettings?.map?.Tile ?? Find.CurrentMap.Tile, false, false, false, false, true, true, 1f, false, true, false, false, false, false, false, null, null, null, null, null, null, null);
                //1.2 PawnGenerationRequest request = new PawnGenerationRequest(kind, faction, PawnGenerationContext.NonPlayer, -1, false, false, false, false, true, true, 1f, false, true, true, true, false, false, false, false, 0f, null, 1f, null, null, null, null, null, null, null, null, null, null, null, null);
                
                //1.4
                PawnGenerationRequest request = new PawnGenerationRequest(
                 kind, faction, 
                 PawnGenerationContext.NonPlayer, // context nonplayer = 2
                 -1, // tile
                     // from Verse.PawnGenerationRequest
                     /*ForceGenerateNewPawn = forceGenerateNewPawn;
                    AllowDead = allowDead;
                    AllowDowned = allowDowned;
                    CanGeneratePawnRelations = canGeneratePawnRelations;
                    MustBeCapableOfViolence = mustBeCapableOfViolence;
                    ColonistRelationChanceFactor = colonistRelationChanceFactor;
                    ForceAddFreeWarmLayerIfNeeded = forceAddFreeWarmLayerIfNeeded;
                    AllowGay = allowGay;
                    AllowPregnant = allowPregnant;
                    AllowFood = allowFood;
                    AllowAddictions = allowAddictions;
                    ForcedTraits = forcedTraits;
                    ProhibitedTraits = prohibitedTraits;
                    Inhabitant = inhabitant;
                    CertainlyBeenInCryptosleep = certainlyBeenInCryptosleep;
                    ForceRedressWorldPawnIfFormerColonist = forceRedressWorldPawnIfFormerColonist;
                    WorldPawnFactionDoesntMatter = worldPawnFactionDoesntMatter;
                    ExtraPawnForExtraRelationChance = extraPawnForExtraRelationChance;
                    RelationWithExtraPawnChanceFactor = relationWithExtraPawnChanceFactor;
                    BiocodeWeaponChance = biocodeWeaponChance;
                    BiocodeApparelChance = biocodeApparelChance;
                    ForceNoIdeo = forceNoIdeo;
                    ForceNoBackstory = forceNoBackstory;
                    ForbidAnyTitle = forbidAnyTitle;
                    ValidatorPreGear = validatorPreGear;
                    ValidatorPostGear = validatorPostGear;
                    MinChanceToRedressWorldPawn = minChanceToRedressWorldPawn;
                    FixedBiologicalAge = fixedBiologicalAge;
                    FixedChronologicalAge = fixedChronologicalAge;
                    FixedGender = fixedGender;
                    FixedLastName = fixedLastName;
                    FixedBirthName = fixedBirthName;
                    FixedTitle = fixedTitle;
                    FixedIdeo = fixedIdeo;
                    ForceDead = forceDead;
                    ForcedXenotype = forcedXenotype;
                    ForcedCustomXenotype = forcedCustomXenotype;*/

                false, false, false, false, false, 1f,  true, true, true, true, false, false, false, false, false,
                0f, 0f, null, 1f, null, null, null, null, null, null, null, null, null, null, null, null, false, false, false, // custom xeno

                    /*AllowedXenotypes = allowedXenotypes;
                    ForceBaselinerChance = forceBaselinerChance;
                    AllowedDevelopmentalStages = developmentalStages;
                    PawnKindDefGetter = pawnKindDefGetter;
                    ExcludeBiologicalAgeRange = excludeBiologicalAgeRange;
                    BiologicalAgeRange = biologicalAgeRange;
                    ForceRecruitable = forceRecruitable);*/

                true, null, null, null, null, null, 1f);

                //1.3
               /* PawnGenerationRequest request = new PawnGenerationRequest(kind, // KindDef
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
                    );*/

                Pawn pawn = PawnGenerator.GeneratePawn(request);
                IntVec3 spawnLoc;
                //CellFinder.TryFindBestPawnStandCell(pawn, out spawnLoc);
                var map = BaseGen.globalSettings?.map ?? Find.CurrentMap;

                CellFinderLoose.TryGetRandomCellWith((x => x.IsValid && rp.rect.Contains(x) && x.GetEdifice(map) == null && x.GetFirstItem(map) == null),
                    map, 100000, out spawnLoc);

                GenSpawn.Spawn(pawn, spawnLoc, map);

                pawn.Kill(null);

                if (pawn?.Corpse is Corpse c && c.TryGetComp<CompRottable>() is CompRottable comp)
                {
                    int n = Rand.Range(0, 45);
                    float m = Rand.Range(0.75f, 1.25f);
                    c.Age += GenDate.TicksPerDay * n;
                    //Log.Message("Rotted corpse");
                    //comp.RotProgress += 9999999;
                    comp.RotProgress += Rand.Range(8000, 12000) * n * m;
                }
            }
        }


        private bool IsWallOrRock(Building b)
        {
            return b != null && (b.def == ThingDefOf.Wall || b.def.building.isNaturalRock);
        }
    }
}
