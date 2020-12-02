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
using RestSharp.Authenticators;

namespace LeagueCLUTest.RiotSharp
{
    public class LeagueSharp
    {
        /// <summary>
        /// The League Client executable name without file extension
        /// </summary>
        const string ExecutableName = "LeagueClient";
        const string LCUUsername = "riot";

        public LeagueRequestor Requestor { get; private set; }

        Process LeagueProcess { get; set; }
        RestClient RestClient;

        public LeagueSharp()
        {
            var procs = Process.GetProcessesByName(LeagueSharp.ExecutableName);

            if (procs.Length == 0)
                throw new LeagueClientNotRunningException(LeagueSharp.ExecutableName);

            LeagueProcess = procs[0];

            Requestor = new LeagueRequestor(LeagueProcess);
        }
    }
}
