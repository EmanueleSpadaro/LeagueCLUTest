using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientPlayerAbility
    {
        public int AbilityLevel { get; set; }
        public string DisplayName { get; set; }
        public string ID { get; set; }
        public string RawDescription { get; set; }
        public string RawDisplayName { get; set; }
    }
}
