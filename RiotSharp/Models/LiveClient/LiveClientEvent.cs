using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp.Enums.LiveClient;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientEvent
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public double EventTime { get; set; }

        public LiveClientEventName EventNameEnum => EventName.ToLiveClientEventName();
    }
}
