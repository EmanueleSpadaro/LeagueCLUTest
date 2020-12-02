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
        public bool ConnectedToPatchServer { get; set; }
        public bool HasUpdatesOnRestart { get; set; }
        public bool WillRestartOnSelfUpdate { get; set; }

        public override string ToString()
            => JsonSerializer.Serialize<LeaguePatchStatus>(this);
    }
}
