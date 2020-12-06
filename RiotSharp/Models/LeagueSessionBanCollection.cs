using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueSessionBanCollection
    {
        public List<int> MyTeamBans { get; set; }
        public int NumBans { get; set; }
        public List<int> TheirTeamBans { get; set; }
    }
}
