using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueSummoner : LeagueAccountIdentifications
    {
        public string DisplayName { get; set; }
        public string InternalName { get; set; }
        public bool NameChangeFlag { get; set; }
        public double PercentCompleteForNextLevel { get; set; }
        public int ProfileIconId { get; set; }
        public string Puuid { get; set; }
        public LeagueRerollPoints RerollPoints { get; set; }
        public int SummonerLevel { get; set; }
        public bool Unnamed { get; set; }
        public long XpSinceLastLevel { get; set; }
        public long XpUntilNextLevel { get; set; }
    }
}
