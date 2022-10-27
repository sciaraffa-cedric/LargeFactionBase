// RimWorld.BaseGen.SymbolResolver_EmptyRoom
using RimWorld.BaseGen;
using Verse;

public class SymbolResolver_EmptyRoom2 : SymbolResolver
{
    public override void Resolve(ResolveParams rp)
    {
        ThingDef thingDef = rp.wallStuff ?? BaseGenUtility.RandomCheapWallStuff(rp.faction);
        TerrainDef floorDef = rp.floorDef ?? BaseGenUtility.CorrespondingTerrainDef(thingDef, beautiful: false, faction: rp.faction);
        if (!rp.noRoof.HasValue || !rp.noRoof.Value)
        {
            BaseGen.symbolStack.Push("roof", rp);
        }
        ResolveParams resolveParams = rp;
        resolveParams.wallStuff = thingDef;
        BaseGen.symbolStack.Push("edgeWalls", resolveParams);
        ResolveParams resolveParams2 = rp;
        resolveParams2.floorDef = floorDef;
        BaseGen.symbolStack.Push("floor", resolveParams2);

        for (int i = 0; i < Rand.Range(24, 48); i++)
        {
            BaseGen.symbolStack.Push("prisonBile", rp);
        }

        for (int i = 0; i < Rand.Range(4, 8); i++)
        {
            BaseGen.symbolStack.Push("prisonFilth", rp);
        }

        BaseGen.symbolStack.Push("corpse", resolveParams2);

        BaseGen.symbolStack.Push("corpse3", resolveParams2);

        //BaseGen.symbolStack.Push("clear", rp);

        if (rp.addRoomCenterToRootsToUnfog.HasValue && rp.addRoomCenterToRootsToUnfog.Value && Current.ProgramState == ProgramState.MapInitializing)
        {
            MapGenerator.rootsToUnfog.Add(rp.rect.CenterCell);
        }
    }
}
