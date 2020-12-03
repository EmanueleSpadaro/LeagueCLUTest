using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.IO;

using RestSharp;

using DotNetstat;

using LeagueCLUTest.RiotSharp.Requestors;
using LeagueCLUTest.RiotSharp.Models;
using LeagueCLUTest.RiotSharp.Exceptions;
using LeagueCLUTest.RiotSharp.Handlers;
using RestSharp.Authenticators;

namespace LeagueCLUTest.RiotSharp
{
    public class LeagueSharp
    {
        /// <summary>
        /// The League Client executable name without file extension
        /// </summary>
        const string ExecutableName = "LeagueClient";

        public LeagueRequestor Requestor { get; private set; }

        private Process LeagueProcess { get; set; }
        private RestClient RestClient;

        public LeagueMatchmakingHandler MatchmakingHandler { get; private set; }

        public LeagueSharp()
        {
            var procs = Process.GetProcessesByName(LeagueSharp.ExecutableName);

            if (procs.Length == 0)
                throw new LeagueClientNotRunningException(LeagueSharp.ExecutableName);

            LeagueProcess = procs[0];

            Requestor = new LeagueRequestor(LeagueProcess);

            //Set up Handlers after Requestor has been instantiated

            MatchmakingHandler = new LeagueMatchmakingHandler(this);
        }
    }
}
