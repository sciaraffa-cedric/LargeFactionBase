using System.Collections.Generic;
using System.Linq;
using RimWorld;
using RimWorld.BaseGen;
using Verse;
using LargeFactionBase;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Interior_PrisonCell4 : SymbolResolver
    {
        private const int FoodStockpileSize = 3;

        public override void Resolve(ResolveParams rp)
        {
            ThingSetMakerParams value = default(ThingSetMakerParams);
            value.techLevel = new TechLevel?((rp.faction == null) ? TechLevel.Spacer : rp.faction.def.techLevel);
            ResolveParams resolveParams = rp;
            resolveParams.thingSetMakerDef = ThingSetMakerDefOf.MapGen_PrisonCellStockpile;
            resolveParams.thingSetMakerParams = new ThingSetMakerParams?(value);
            resolveParams.innerStockpileSize = new int?(3);
            BaseGen.symbolStack.Push("innerStockpile", resolveParams);

            InteriorSymbolResolverUtility.PushBedroomHeatersCoolersAndLightSourcesSymbols(rp, false);
            BaseGen.symbolStack.Push("prisonerSpot", rp);
            for (int i = 0; i < Rand.Range(3, 9); i++)
            {
                BaseGen.symbolStack.Push("prisonerSpot", rp);
            }

            for (int i = 0; i < Rand.Range(24, 48); i++)
            {
                BaseGen.symbolStack.Push("prisonBile", rp);
            }

            for (int i = 0; i < Rand.Range(4, 8); i++)
            {
                BaseGen.symbolStack.Push("prisonFilth", rp);
            }

            for (int i = 0; i < Rand.Range(2, 6); i++)
            {
                BaseGen.symbolStack.Push("corpse", rp);
            }
            for (int i = 0; i < Rand.Range(1, 2); i++)
            {
                BaseGen.symbolStack.Push("corpse2", rp);
            }
            for (int i = 0; i < Rand.Range(2, 4); i++)
            {
                BaseGen.symbolStack.Push("corpse3", rp);
            }

        }
        /*BaseGen.symbolStack.Push("corpse", rp);
        BaseGen.symbolStack.Push("corpse", rp);
        BaseGen.symbolStack.Push("corpse", rp);
        if (Rand.Value > 0.5f)
        {
            BaseGen.symbolStack.Push("corpse", rp);
        }
        if (Rand.Value > 0.5f)
        {
            BaseGen.symbolStack.Push("corpse", rp);
        }
        if (Rand.Value > 0.5f)
        {
            BaseGen.symbolStack.Push("corpse", rp);
        }*/

    }
}
