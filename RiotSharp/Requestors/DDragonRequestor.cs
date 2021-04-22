using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp.Models;
using LeagueCLUTest.RiotSharp.Models.DDragon;

using RestSharp;

namespace LeagueCLUTest.RiotSharp.Requestors
{
    public partial class LeagueRequestor
    {
        public class DDragonRequestor
        {
            
            private RestClient DDragonRestClient { get; set; }

            private LeaguePatchGameVersion CachedGameVersion;
            /// <summary>
            /// Array containing every single supported language ID 
            /// </summary>
            public string[] Languages { get; private set; }

            public string DefaultLanguage { get; set; }
            public DDragonChampion[] Champions;
            public DDragonRequestor(LeaguePatchGameVersion version)
            {
                DDragonRestClient = new RestClient($"https://ddragon.leagueoflegends.com/cdn/")
                { RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true };
                CachedGameVersion = version;

                Languages = JsonSerializer.Deserialize<string[]>(DDragonRestClient.Execute(GetLanguages).Content, LeagueRequestor.JsonSerializerOptions);
                DefaultLanguage = "en_US";
            }

            private static RestRequest GetLanguages = new RestRequest("languages.json", Method.GET);
        }
    }
}
