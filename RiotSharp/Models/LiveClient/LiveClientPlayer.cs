using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientPlayer
    {
        public string ChampionName { get; set; }
        public bool IsBot { get; set; }
        public bool IsDead { get; set; }
        public List<LiveClientItem> Items { get; set; }
        public int Level { get; set; }
        public string Position { get; set; }
        public string RawChampionName { get; set; }
        public double RespawnTimer { get; set; }
        public LiveClientMainRuneSet Runes { get; set; }
        public LiveClientPlayerScore Scores { get; set; }
        public int SkinID { get; set; }
        public string SummonerName { get; set; }
        public LiveClientSummonerSpellSet SummonerSpells { get; set; }
        public string Team { get; set; }
    }
}
