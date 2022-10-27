﻿using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld.BaseGen;
using RimWorld;

namespace LargeFactionBase
{
    public class SymbolResolver_ThingSet2 : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;

            ThingSetMakerDef thingSetMakerDef = rp.thingSetMakerDef ?? LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile2 ;
            ThingSetMakerParams? thingSetMakerParams = rp.thingSetMakerParams;
            ThingSetMakerParams parms;
            if (thingSetMakerParams.HasValue)
            {
                parms = rp.thingSetMakerParams.Value;
            }
            else
            {
                int num = rp.rect.Cells.Count((IntVec3 x) => x.Standable(map) && x.GetFirstItem(map) == null);
                parms = default(ThingSetMakerParams);
                parms.countRange = new IntRange?(new IntRange(num, num));
                parms.techLevel = new TechLevel?((rp.faction == null) ? TechLevel.Undefined : rp.faction.def.techLevel);
            }
            List<Thing> list = thingSetMakerDef.root.Generate(parms);

            for (int i = 0; i < list.Count; i++)
            {
                ResolveParams resolveParams = rp;
                resolveParams.singleThingToSpawn = list[i];
                BaseGen.symbolStack.Push("thing", resolveParams);
            }
        }
    }
}