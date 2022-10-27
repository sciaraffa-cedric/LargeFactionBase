﻿using System;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_BasePart_Indoors_Leaf_PrisonCell4 : SymbolResolver
    {
        /*public override bool CanResolve(ResolveParams rp)
        {
            return base.CanResolve(rp) && BaseGen.globalSettings.basePart_barracksResolved >= BaseGen.globalSettings.minBarracks;
        }*/ //2021-07-15

        private const float MaxCoverage = 0.08f;

        public override bool CanResolve(ResolveParams rp)
        {
            if (!base.CanResolve(rp))
            {
                return false;
            }
            if (BaseGen.globalSettings.basePart_throneRoomsResolved < BaseGen.globalSettings.minThroneRooms)
            {
                return false;
            }
            if (BaseGen.globalSettings.basePart_barracksResolved < BaseGen.globalSettings.minBarracks)
            {
                return false;
            }
            if (BaseGen.globalSettings.basePart_worshippedTerminalsResolved < BaseGen.globalSettings.requiredWorshippedTerminalRooms && SymbolResolver_BasePart_Indoors_Leaf_WorshippedTerminal.CanResolve("basePart_indoors_leaf", rp))
            {
                return false;
            }
            return true;
        }

        public override void Resolve(ResolveParams rp)
        {
            BaseGen.symbolStack.Push("prisonCell4", rp);
        }

    }
}