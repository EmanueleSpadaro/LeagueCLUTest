using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    /// <summary>
    /// Provides a class usable in JsonSerializer to get LiveClientEvents Models
    /// </summary>
    public class LiveClientSerializableEvent
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public double EventTime { get; set; }
        public string KillerName { get; set; }
        public List<string> Assisters { get; set; }
        public string TurretKilled { get; set; }
        public string InhibKilled { get; set; }
        public string DragonType { get; set; }
        public string Stolen { get; set; }
        public string VictimName { get; set; }
        public int KillStreak { get; set; }
        public string Acer { get; set; }
        public string AcingTeam { get; set; }
    }
}
