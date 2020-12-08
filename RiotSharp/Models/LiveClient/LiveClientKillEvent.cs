using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientKillEvent : LiveClientEvent
    {
        public string KillerName { get; set; }
        public List<string> Assisters { get; set; }

        //RiotSharp additions
        public bool IsSoloKill { get => Assisters.Count == 0; }
    }
}
