using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeaguePatchStatus
    {
        public bool ConnectedToPatchServer;
        public bool HasUpdatesOnRestart;
        public bool WillRestartOnSelfUpdate;
    }
}
