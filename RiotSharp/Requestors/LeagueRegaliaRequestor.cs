using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;

using RestSharp;

using LeagueCLUTest.RiotSharp.Enums;
using LeagueCLUTest.RiotSharp.Models;

namespace LeagueCLUTest.RiotSharp.Requestors
{
    public partial class LeagueRequestor
    {
        /// <summary>
        /// Endpoints used to retrieve information regarding ranked positions and/or ranks
        /// </summary>
        public class LeagueRegaliaRequestor
        {
            private RestClient RestClient;
            public LeagueRegaliaRequestor(RestClient client) => RestClient = client;

            private static RestRequest GetCurrentSummonerRegaliaRequest = new RestRequest("/lol-regalia/v2/current-summoner/regalia", Method.GET);
            private static RestRequest GetSummonerRegaliaRequest; //new RestRequest("/lol-regalia/v2/summoners/{summonerId}/regalia", Method.GET);
            private static RestRequest GetQueueSpecificRegaliaRequest;// new RestRequest("/lol-regalia/v2/summoners/{summonerId}/queues/{queue}/regalia", Method.GET);

            /// <summary>
            /// Performs a request to obtain current player's regalia
            /// </summary>
            /// <returns>Player's regalia</returns>
            public async Task<LeagueRegalia> GetCurrentSummonerRegalia()
            {
                var res = await RestClient.ExecuteAsync(GetCurrentSummonerRegaliaRequest);
                return JsonSerializer.Deserialize<LeagueRegalia>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            /// <summary>
            /// Performs a request to obtain a player's regalia
            /// </summary>
            /// <param name="SummonerId">Desired player's regalia summonerId</param>
            /// <returns>Player's regalia</returns>
            public async Task<LeagueRegalia> GetSummonerRegalia(long SummonerId)
            {
                GetSummonerRegaliaRequest = new RestRequest($"/lol-regalia/v2/summoners/{SummonerId}/regalia", Method.GET);
                var res = await RestClient.ExecuteAsync(GetSummonerRegaliaRequest);
                return JsonSerializer.Deserialize<LeagueRegalia>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            /// <summary>
            /// Performs a request to obtain a player's regalia regarding a specific queue
            /// </summary>
            /// <param name="SummonerId">Desired player's regalia summonerId</param>
            /// <param name="Queue">Specific queue</param>
            /// <returns>Player's regalia</returns>
            public async Task<LeagueRegalia> GetQueueSpecificRegalia(long SummonerId, LeagueQueueType Queue)
            {
                GetQueueSpecificRegaliaRequest = new RestRequest($"/lol-regalia/v2/summoners/{SummonerId}/queues/{Queue.AsString()}/regalia");
                var res = await RestClient.ExecuteAsync(GetQueueSpecificRegaliaRequest);
                return JsonSerializer.Deserialize<LeagueRegalia>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            /// <summary>
            /// Performs a request to obtain a player's regalia
            /// </summary>
            /// <param name="Summoner">League Summoner</param>
            /// <returns>Player's regalia</returns>
            public async Task<LeagueRegalia> GetSummonerRegalia(LeagueSummoner Summoner) => await GetSummonerRegalia(Summoner.SummonerId);

            /// <summary>
            /// Performs a request to obtain a player's regalia regarding a specific queue
            /// </summary>
            /// <param name="Summoner">Desired player's regalia</param>
            /// <param name="Queue">Specific queue</param>
            /// <returns>Player's regalia</returns>
            public async Task<LeagueRegalia> GetQueueSpecificRegalia(LeagueSummoner Summoner, LeagueQueueType Queue) => await GetQueueSpecificRegalia(Summoner.SummonerId, Queue);



        }
    }
}
