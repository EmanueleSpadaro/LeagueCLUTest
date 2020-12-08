using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientBasicGame
    {
        public string GameMode { get; set; }
        public double GameTime { get; set; }
        public string MapName { get; set; }
        public int MapNumber { get; set; }
        public string MapTerrain { get; set; }
    }
}
