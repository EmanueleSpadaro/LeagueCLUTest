using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueRerollPoints
    {
        public int CurrentPoints { get; set; }
        public int MaxRolls { get; set; }
        public int NumberOfRolls { get; set; }
        public int PointsCostToRoll { get; set; }
        public int PointsToReroll { get; set; }
    }
}
