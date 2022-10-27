﻿using System;
using Verse;
using Verse.AI;
using Verse.AI.Group;

namespace RimWorld
{
    public class LordToil_DefendBase2 : LordToil
    {
        public IntVec3 baseCenter;

        public override IntVec3 FlagLoc
        {
            get
            {
                return this.baseCenter;
            }
        }

        public LordToil_DefendBase2(IntVec3 baseCenter)
        {
            this.baseCenter = baseCenter;
        }

        public override void UpdateAllDuties()
        {
            for (int i = 0; i < this.lord.ownedPawns.Count; i++)
            {
                this.lord.ownedPawns[i].mindState.duty = new PawnDuty(LargeFactionBase.Large_DutyDefOf.DefendBase2, this.baseCenter, -1f);
            }
        }
    }
}