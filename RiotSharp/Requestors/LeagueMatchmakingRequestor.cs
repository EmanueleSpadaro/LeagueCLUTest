using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

namespace LeagueCLUTest.RiotSharp.Requestors
{
    public partial class LeagueRequestor
    {
        public class LeagueMatchmakingRequestor
        {
            private RestClient RestClient;
            public LeagueMatchmakingRequestor(RestClient RestClient) => this.RestClient = RestClient;
        }
    }
}
