using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

using LeagueCLUTest.RiotSharp.Models;

using System.Text.Json;
using System.Text.Json.Serialization;
namespace LeagueCLUTest.RiotSharp.Requestors
{
    public partial class LeagueRequestor
    {
        public class LeagueSummonerRequestor
        {
            private RestClient RestClient;
            public LeagueSummonerRequestor(RestClient client) => RestClient = client;

            private static RestRequest GetCurrentSummonerRequest = new RestRequest("/lol-summoner/v1/current-summoner", Method.GET);
            private static RestRequest GetNameAvailabilityRequest = new RestRequest("/lol-summoner/v1/check-name-availability", Method.GET);
            private static RestRequest GetNewSummonerNameAvailabilityRequest = new RestRequest("/lol-summoner/v1/check-name-availability-new-summoners", Method.GET);
            private static RestRequest GetAccountAndSummonerIdsRequest = new RestRequest("/lol-summoner/v1/account-and-summoner-ids", Method.GET);
            private static RestRequest GetRerollPointsRequest = new RestRequest("/lol-summoner/v1/rerollPoints", Method.GET);
            private static RestRequest GetSummonerRequest = new RestRequest("/lol-summoner/v1/summoners", Method.GET);

            public async Task<bool> GetNameAvailability(string Name)
            {
                GetNameAvailabilityRequest.AddOrUpdateParameter("name", Name);
                var res = await RestClient.ExecuteAsync(GetNameAvailabilityRequest);
                return res.Content == "true";
            }
            public async Task<bool> GetNewSummonerNameAvailability(string Name)
            {
                GetNewSummonerNameAvailabilityRequest.AddOrUpdateParameter("name", Name);
                var res = await RestClient.ExecuteAsync(GetNewSummonerNameAvailabilityRequest);
                return res.Content == "true";
            }

            public async Task<LeagueAccountIdentifications> GetAccountAndSummonerIds()
            {
                var res = await RestClient.ExecuteAsync(GetAccountAndSummonerIdsRequest);
                return JsonSerializer.Deserialize<LeagueAccountIdentifications>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            public async Task<LeagueSummoner> GetCurrentSummoner()
            {
                var res = await RestClient.ExecuteAsync(GetCurrentSummonerRequest);
                return JsonSerializer.Deserialize<LeagueSummoner>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            public async Task<LeagueRerollPoints> GetRerollPoints()
            {
                var res = await RestClient.ExecuteAsync(GetRerollPointsRequest);
                return JsonSerializer.Deserialize<LeagueRerollPoints>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            public async Task<LeagueSummoner> GetSummoner(string SummonerName)
            {
                GetSummonerRequest.AddOrUpdateParameter("name", SummonerName);
                var res = await RestClient.ExecuteAsync(GetSummonerRequest);
                return JsonSerializer.Deserialize<LeagueSummoner>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

        }
    }
}
