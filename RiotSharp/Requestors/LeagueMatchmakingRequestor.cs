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
        public class LeagueMatchmakingRequestor
        {
            private RestClient RestClient;
            public LeagueMatchmakingRequestor(RestClient RestClient) => this.RestClient = RestClient;

            private static RestRequest ReadyCheckRequest = new RestRequest("/lol-matchmaking/v1/ready-check", Method.GET, DataFormat.Json);
            private static RestRequest ReadyCheckAcceptRequest = new RestRequest("/lol-matchmaking/v1/ready-check/accept", Method.POST);
            private static RestRequest ReadyCheckDeclineRequest = new RestRequest("/lol-matchmaking/v1/ready-check/decline", Method.POST);

            private static RestRequest _DeleteSearchRequest = new RestRequest("/lol-matchmaking/v1/search", Method.DELETE);
            private static RestRequest _GetSearchRequest = new RestRequest("/lol-matchmaking/v1/search", Method.GET);
            private static RestRequest _PostSearchRequest = new RestRequest("/lol-matchmaking/v1/search", Method.POST);
            private static RestRequest _PutSearchRequest = new RestRequest("/lol-matchmaking/v1/search", Method.PUT);

            public async Task<LeagueReadyCheck> GetReadyCheckAsync()
            {
                var res = await RestClient.ExecuteAsync(ReadyCheckRequest);
                return JsonSerializer.Deserialize<LeagueReadyCheck>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            public async Task AcceptGameAsync() => await RestClient.ExecuteAsync(ReadyCheckAcceptRequest);
            public async Task DeclineGameAsync() => await RestClient.ExecuteAsync(ReadyCheckDeclineRequest);
            public async Task DeleteSearchAsync() => await RestClient.ExecuteAsync(_DeleteSearchRequest);
            
            public async Task<LeagueMatchmaking> GetSearchAsync()
            {
                var res = await RestClient.ExecuteAsync(_GetSearchRequest);
                return JsonSerializer.Deserialize<LeagueMatchmaking>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }
        }
    }
}
