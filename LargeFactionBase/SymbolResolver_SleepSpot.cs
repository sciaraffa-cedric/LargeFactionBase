// RimWorld.BaseGen.SymbolResolver_Bed
using RimWorld;
using RimWorld.BaseGen;
using Verse;

public class SymbolResolver_SleepSpot : SymbolResolver
{
    public override void Resolve(ResolveParams rp)
    {
        ThingDef singleThingDef = ThingDefOf.SleepingSpot;
        ResolveParams resolveParams = rp;
        resolveParams.singleThingDef = singleThingDef;
        resolveParams.skipSingleThingIfHasToWipeBuildingOrDoesntFit = rp.skipSingleThingIfHasToWipeBuildingOrDoesntFit ?? true;
        BaseGen.symbolStack.Push("thing", resolveParams);
    }
}
