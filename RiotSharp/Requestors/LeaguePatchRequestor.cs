using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;

using RestSharp;

using LeagueCLUTest.RiotSharp.Models;

namespace LeagueCLUTest.RiotSharp.Requestors
{
    public partial class LeagueRequestor
    {
        public class LeaguePatchRequestor
        {
            private RestClient RestClient;

            public LeaguePatchRequestor(RestClient RestClient) => this.RestClient = RestClient;


            private static RestRequest CheckingEnabledRequest = new RestRequest("/lol-patch/v1/checking-enabled", Method.GET);
            private static RestRequest GameVersionRequest = new RestRequest("/lol-patch/v1/game-version", Method.GET);
            private static RestRequest StatusRequest = new RestRequest("lol-patch/v1/status", Method.GET);

            public async Task<LeaguePatchGameVersion> GetGameVersionAsync()
            {
                var response = await RestClient.ExecuteAsync(GameVersionRequest);
                return new LeaguePatchGameVersion(response.Content);
            }

            public async Task<bool> GetCheckingEnabledAsync()
            {
                var response = await RestClient.ExecuteAsync(CheckingEnabledRequest);
                return response.Content == "true";
            }

            public async Task<LeaguePatchStatus> GetStatusAsync()
            {
                var response = await RestClient.ExecuteAsync(StatusRequest);
                var patchStatus = JsonSerializer.Deserialize<LeaguePatchStatus>(response.Content, JsonSerializerOptions);
                return patchStatus;
            }
        }
    }
}
