using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

using RestSharp;
using RestSharp.Authenticators;

using LeagueCLUTest.RiotSharp.Models;

namespace LeagueCLUTest.RiotSharp.Requestors
{
    public partial class LeagueRequestor
    {
        private static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        private RestClient RestClient { get; set; }

        /// <summary>
        /// The username used in HttpBasicAuthentication by RestClient
        /// </summary>
        private const string LCUUsername = "riot";

        #region Implemented Requestors [Be sure to create their relative instance in constructor]
        public LeaguePatchRequestor LeaguePatch { get; private set; }
        public RiotClientRequestor RiotClient { get; private set; }
        public LeagueMatchmakingRequestor LeagueMatchmaking { get; private set; }
        #endregion

        public LeagueRequestor(Process LeagueProcess)
        {
            var lockFilepath = Path.Combine(Path.GetDirectoryName(LeagueProcess.MainModule.FileName), "lockfile");


            LeagueLockData LockData;

            using (var fs = File.Open(lockFilepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs))
                LockData = new LeagueLockData(sr.ReadToEnd());

            RestClient = new RestClient($"https://127.0.0.1:{LockData.Port}");

            //Given the fact that LeagueClient doesn't use any secure HTTPS certificate, we override our RestClient Certificate SSL Validation Callback
            RestClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            //We add our token as Authentication parameter
            RestClient.Authenticator = new HttpBasicAuthenticator(LeagueRequestor.LCUUsername, LockData.Password);


            LeaguePatch = new LeaguePatchRequestor(this.RestClient);
            RiotClient = new RiotClientRequestor(this.RestClient);
            LeagueMatchmaking = new LeagueMatchmakingRequestor(this.RestClient);
        }
    }
}
