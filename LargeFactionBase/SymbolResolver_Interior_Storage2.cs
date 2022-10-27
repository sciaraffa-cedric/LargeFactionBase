﻿using System;
using Verse;
using RimWorld.BaseGen;
using RimWorld;

namespace LargeFactionBase
{
    public class SymbolResolver_Interior_Storage2 : SymbolResolver
    {
        private const float SpawnPassiveCoolerIfTemperatureAbove = 15f;

        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;
            //BaseGen.symbolStack.Push("corpse3", rp);
            BaseGen.symbolStack.Push("stockpile2", rp);
            if (map.mapTemperature.OutdoorTemp > 15f)
            {
                ResolveParams resolveParams = rp;
                resolveParams.singleThingDef = ThingDefOf.PassiveCooler;
                BaseGen.symbolStack.Push("edgeThing", resolveParams);
            }
            //BaseGen.symbolStack.Push("corpse3", rp);
        }
    }
}