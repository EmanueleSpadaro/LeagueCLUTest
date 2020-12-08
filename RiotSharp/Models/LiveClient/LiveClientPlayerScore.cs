using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientPlayerScore
    {
        public int Assists { get; set; }
        public int CreepScore { get; set; }
        public int Deaths { get; set; }
        public int Kills { get; set; }
        public double WardScore { get; set; }
    }
}
