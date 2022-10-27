using System;
using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_RandomlyPlaceJointOnTables : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;

            ThingDef singleThingDef = Rand.Element<ThingDef>(LargeFactionBase.Large_DefOf.PsychiteTea,
     LargeFactionBase.Large_DefOf.Beer, LargeFactionBase.Large_DefOf.SmokeleafJoint);

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
                        resolveParams.singleThingStackCount = Rand.Range(3, 6);
                        BaseGen.symbolStack.Push("thing", resolveParams);
                    }
                }
                iterator.MoveNext();
            }
        }
    }
}

/*		if (!PossibleRawFood(techLevel).TryRandomElement(out var result))
		{
			return null;
		}
		Thing thing = ThingMaker.MakeThing(result);
		int max = Mathf.Min(result.stackLimit, 75);
		thing.stackCount = Rand.RangeInclusive(1, max);
		return thing;
*/