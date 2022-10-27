using System;
using System.Collections.Generic;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_RandomlyPlaceDrugOnTables : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;
            /*ThingDef singleThingDef = (rp.faction != null && rp.faction.def.techLevel.IsNeolithicOrWorse()) ? LargeFactionBase.Large_DefOf.PsychiteTea :
                LargeFactionBase.Large_DefOf.GoJuice ;*/

            ThingDef singleThingDef = (rp.faction != null && rp.faction.def.techLevel.IsNeolithicOrWorse()) ? Rand.Element<ThingDef>(LargeFactionBase.Large_DefOf.PsychiteTea,
    LargeFactionBase.Large_DefOf.Ambrosia) :
    rp.singleThingDef ?? Rand.Element<ThingDef>(LargeFactionBase.Large_DefOf.GoJuice, LargeFactionBase.Large_DefOf.WakeUp, ThingDefOf.Chocolate,
    LargeFactionBase.Large_DefOf.Ambrosia);

            CellRect.CellRectIterator iterator = rp.rect.GetIterator();
            while (!iterator.Done())
            {
                List<Thing> thingList = iterator.Current.GetThingList(map);
                for (int i = 0; i < thingList.Count; i++)
                {
                    if (thingList[i].def.IsTable && Rand.Chance(0.15f))
                    {
                        ResolveParams resolveParams = rp;
                        resolveParams.rect = CellRect.SingleCell(iterator.Current);
                        resolveParams.singleThingDef = singleThingDef;
                        resolveParams.singleThingStackCount = Rand.Range(1, 3);
                        BaseGen.symbolStack.Push("thing", resolveParams);
                    }
                }
                iterator.MoveNext();
            }
        }
    }
}