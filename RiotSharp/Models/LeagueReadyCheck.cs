using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    /// <summary>
    /// Class containing information regarding a matchmaking queue
    /// </summary>
    public class LeagueReadyCheck
    {
        public List<int> DeclinerIDs { get; set; }
        public string DodgeWarning { get; set; }
        public string PlayerResponse { get; set; }
        public string State { get; set; }
        public bool SuppressUX { get; set; }
        public double Timer { get; set; }

        public bool IsSearching { get => !(State is null); }
    }
}
