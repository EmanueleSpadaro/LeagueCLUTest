using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Enums
{
    public enum LeagueChampionSelectPhase
    {
        BAN_PICK,
        /// <summary>
        /// Game set, the last timer is running off (when nobody can do anything anymore)
        /// </summary>
        FINALIZING
    }
}
