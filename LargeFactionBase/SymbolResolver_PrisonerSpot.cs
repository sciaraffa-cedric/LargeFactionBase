// RimWorld.BaseGen.SymbolResolver_PrisonerBed
using System;
using RimWorld;
using RimWorld.BaseGen;
using Verse;

public class SymbolResolver_PrisonerSpot : SymbolResolver
{
    public override void Resolve(ResolveParams rp)
    {
        ResolveParams resolveParams = rp;
        Action<Thing> prevPostThingSpawn = resolveParams.postThingSpawn;
        resolveParams.postThingSpawn = delegate (Thing x)
        {
            if (prevPostThingSpawn != null)
            {
                prevPostThingSpawn(x);
            }
            Building_Bed building_Bed = x as Building_Bed;
            if (building_Bed != null)
            {
                building_Bed.ForPrisoners = true;
            }
        };
        BaseGen.symbolStack.Push("sleepSpot", resolveParams);
    }
}
