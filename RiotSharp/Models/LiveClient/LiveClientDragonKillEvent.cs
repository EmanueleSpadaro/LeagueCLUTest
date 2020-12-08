using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp.Enums.LiveClient;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientDragonKillEvent : LiveClientStealableKillEvent
    {
        public string DragonType { get; set; }

        public LiveClientDragonType DragonTypeEnum { get => DragonType.ToLiveClientDragonType(); }
    }
}
