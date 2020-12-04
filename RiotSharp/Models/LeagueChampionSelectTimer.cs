using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueChampionSelectTimer
    {
        public long AdjustedTimeLeftInPhase { get; set; }
        public long InternalNowInEpochMs { get; set; }
        public bool IsInfinite { get; set; }
        public string Phase { get; set; }
        public long TotalTimeInPhase { get; set; }
    }
}
