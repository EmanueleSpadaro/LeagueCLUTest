using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp.Enums;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueRegalia
    {
        public string BannerType { get; set; }
        public string CrestType { get; set; }
        public LeagueRankedEntry HighestRankedEntry { get; set; }
        public string LastSeasonHighestRank { get; set; }
        public string PreferredBannerType { get; set; }
        public string PreferredCrestType { get; set; }
        public int ProfileIconId { get; set; }
        public int SummonerLevel { get; set; }

        //Enum additions
        public LeagueRank LastSeasonHighestRankEnum { get => LastSeasonHighestRank.ToLeagueRank(); }
    }
}
