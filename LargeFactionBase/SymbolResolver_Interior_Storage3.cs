﻿using System;
using Verse;
using RimWorld.BaseGen;
using RimWorld;

namespace LargeFactionBase
{
    public class SymbolResolver_Interior_Storage3 : SymbolResolver
    {
        private const float SpawnPassiveCoolerIfTemperatureAbove = 15f;

        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;

            BaseGen.symbolStack.Push("stockpile3", rp);
            if (map.mapTemperature.OutdoorTemp > 15f)
            {
                ResolveParams resolveParams = rp;
                resolveParams.singleThingDef = ThingDefOf.PassiveCooler;
                BaseGen.symbolStack.Push("edgeThing", resolveParams);
            }

            BaseGen.symbolStack.Push("corpse3", rp);

            for (int i = 0; i < Rand.Range(2, 8); i++)
            {
                BaseGen.symbolStack.Push("prisonBile", rp);
            }
        }
    }
}