using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using LeagueCLUTest.RiotSharp.Models;
using System.Text.Json;

namespace LeagueCLUTest.RiotSharp.Requestors
{
    public partial class LeagueRequestor
    {
        public class LeagueChampionSelectRequestor
        {
            private RestClient RestClient;
            public LeagueChampionSelectRequestor(RestClient RestClient) => this.RestClient = RestClient;


            private static RestRequest CurrentChampionRequest = new RestRequest("/lol-champ-select/v1/current-champion");
            private static RestRequest GetCurrentSessionRequest = new RestRequest("/lol-champ-select/v1/session");

            public async Task<int> GetCurrentChampionID()
            {
                var res = await RestClient.ExecuteAsync(CurrentChampionRequest);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    return Convert.ToInt32(res.Content);

                return default;
            }
            public async Task<LeagueSession> GetCurrentSession()
            {
                var res = await RestClient.ExecuteAsync(GetCurrentSessionRequest);
                return JsonSerializer.Deserialize<LeagueSession>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }
        }
    }
}
