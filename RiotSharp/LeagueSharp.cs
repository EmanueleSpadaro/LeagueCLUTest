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

        Process LeagueProcess { get; set; }
        protected LeagueLockData LockData;

        RestClient RestClient;

        public LeagueSharp()
        {
            var procs = Process.GetProcessesByName(LeagueSharp.ExecutableName);

            if (procs.Length == 0)
                throw new LeagueClientNotRunningException(LeagueSharp.ExecutableName);

            LeagueProcess = procs[0];

            var lockFilepath = Path.Combine(Path.GetDirectoryName(LeagueProcess.MainModule.FileName), "lockfile");

            using (var fs = File.Open(lockFilepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs))
                LockData = new LeagueLockData(sr.ReadToEnd());

            



            RestClient = new RestClient($"https://127.0.0.1:{LockData.Port}");
            //Given the fact that LeagueClient doesn't use any secure HTTPS certificate, we override our RestClient Certificate SSL Validation Callback
            RestClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            //We add our token as Authentication parameter
            this.RestClient.Authenticator = new HttpBasicAuthenticator(LeagueSharp.LCUUsername, LockData.Password);

            var restReq = new RestRequest("/riotclient/region-locale", DataFormat.Json);

            var response = RestClient.Get(restReq);
        }
    }
}
