using System;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_MiniR : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            ThingDef singleThingDef = Rand.Element<ThingDef>(ThingDefOf.Filth_Blood, ThingDefOf.Filth_CorpseBile, ThingDefOf.Filth_DriedBlood);

            ResolveParams resolveParams = rp;
            resolveParams.singleThingDef = singleThingDef;
            bool? skipSingleThingIfHasToWipeBuildingOrDoesntFit = rp.skipSingleThingIfHasToWipeBuildingOrDoesntFit;
            resolveParams.skipSingleThingIfHasToWipeBuildingOrDoesntFit = new bool?(!skipSingleThingIfHasToWipeBuildingOrDoesntFit.HasValue || skipSingleThingIfHasToWipeBuildingOrDoesntFit.Value);
            BaseGen.symbolStack.Push("thing", resolveParams);
        }
    }
}