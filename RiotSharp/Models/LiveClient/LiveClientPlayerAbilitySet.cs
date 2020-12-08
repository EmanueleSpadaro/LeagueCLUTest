using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientPlayerAbilitySet
    {
        public LiveClientPlayerAbility Q { get; set; }
        public LiveClientPlayerAbility W { get; set; }
        public LiveClientPlayerAbility E { get; set; }
        public LiveClientPlayerAbility R { get; set; }
        public LiveClientPlayerAbility Passive { get; set; }
    }
}
