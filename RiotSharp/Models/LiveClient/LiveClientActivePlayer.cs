using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    /// <summary>
    /// A player instance inside the Live Client
    /// </summary>
    public class LiveClientActivePlayer
    {
        public LiveClientPlayerAbilitySet Abilities { get; set; }
        public LiveClientChampionStats ChampionStats { get; set; }
        public double CurrentGold { get; set; }
        public LiveClientRuneSet FullRunes { get; set; }
        public int Level { get; set; }
        public string SummonerName { get; set; }
    }
}
