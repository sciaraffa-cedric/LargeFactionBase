﻿using System;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_MedBed : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            ThingDef singleThingDef = (rp.faction != null && rp.faction.def.techLevel.IsNeolithicOrWorse()) ? rp.singleThingDef ?? ThingDefOf.Bedroll :
                rp.singleThingDef ?? Rand.Element<ThingDef>(LargeFactionBase.Large_DefOf.HospitalBed, ThingDefOf.Bed);
            ResolveParams resolveParams = rp;
            resolveParams.singleThingDef = singleThingDef;
            bool? skipSingleThingIfHasToWipeBuildingOrDoesntFit = rp.skipSingleThingIfHasToWipeBuildingOrDoesntFit;
            resolveParams.skipSingleThingIfHasToWipeBuildingOrDoesntFit = new bool?(!skipSingleThingIfHasToWipeBuildingOrDoesntFit.HasValue || skipSingleThingIfHasToWipeBuildingOrDoesntFit.Value);
            BaseGen.symbolStack.Push("thing", resolveParams);
        }
    }
}
