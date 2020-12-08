using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientTurretKillEvent : LiveClientKillEvent
    {
        public string TurretKilled { get; set; }
    }
}
