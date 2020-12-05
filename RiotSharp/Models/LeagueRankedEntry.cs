using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp.Enums;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueRankedEntry
    {
        public string Division { get; set; }
        public string QueueType { get; set; }
        public int SplitRewardLevel { get; set; }
        public string Tier { get; set; }

        //Enum additions
        public LeagueDivision DivisionEnum { get => Division.ToLeagueDivision(); }
        public LeagueQueueType QueueTypeEnum { get => QueueType.ToLeagueQueueType(); }
        public LeagueRank TierEnum { get => Tier.ToLeagueRank(); }
    }
}
