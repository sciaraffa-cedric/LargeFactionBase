﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Interior_DiningRoom3 : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            BaseGen.symbolStack.Push("indoorLighting", rp);
            /*if (rp.faction.def.techLevel.IsNeolithicOrWorse())
                // if (rp.faction.def.techLevel < 3)
                {
                BaseGen.symbolStack.Push("randomlyPlacePemmicanOnTables", rp);
            }
            else
            {
                BaseGen.symbolStack.Push("randomlyPlaceMealFineOnTables", rp);
                BaseGen.symbolStack.Push("randomlyPlaceMealLavishOnTables", rp);
            }*/
            BaseGen.symbolStack.Push("randomlyPlacePemmicanOnTables", rp);
            BaseGen.symbolStack.Push("randomlyPlaceMealFineOnTables", rp);
            BaseGen.symbolStack.Push("randomlyPlaceMealLavishOnTables", rp);
            BaseGen.symbolStack.Push("placeChairsNearTables", rp);

            int num = Mathf.Max(GenMath.RoundRandom((float)rp.rect.Area / 20f), 1);
            for (int i = 0; i < num; i++)
            {
                ResolveParams resolveParams = rp;
                resolveParams.singleThingDef = ThingDefOf.Table2x2c;
                BaseGen.symbolStack.Push("thing", resolveParams);
            }

        }
    }
}
