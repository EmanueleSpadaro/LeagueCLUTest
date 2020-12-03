using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueMatchmaking
    {
        public double EstimatedQueueTime { get; set; }
        public bool IsCurrentlyInQueue { get; set; }
        public string LobbyID { get; set; }
        public int QueueID { get; set; }
        public LeagueReadyCheck ReadyCheck { get; set; }
        public string SearchState { get; set; }

        public double TimeInQueue { get; set; }

    }
}
