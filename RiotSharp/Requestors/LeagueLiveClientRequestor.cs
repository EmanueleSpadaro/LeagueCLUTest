using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

using System.Text.Json;
using System.Text.Json.Serialization;

using LeagueCLUTest.RiotSharp.Models.LiveClient;
using LeagueCLUTest.RiotSharp.Enums.LiveClient;

namespace LeagueCLUTest.RiotSharp.Requestors
{
    partial class LeagueRequestor
    {
        public class LeagueLiveClientRequestor
        {
            private RestClient LiveClientRestClient;

            public LeagueLiveClientRequestor() => LiveClientRestClient = new RestClient("https://127.0.0.1:2999/liveclientdata")
            { RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true };
        

            //private static RestRequest GetAllGameDataRequest = new RestRequest("/allgamedata", Method.GET); [Not implented given Riot suggestion]
            private static RestRequest GetActivePlayerRequest = new RestRequest("/activeplayer", Method.GET);
            private static RestRequest GetActivePlayerNameRequest = new RestRequest("/activeplayername", Method.GET);
            private static RestRequest GetActivePlayerAbilitiesRequest = new RestRequest("/activeplayerabilities", Method.GET);
            private static RestRequest GetActivePlayerRunesRequest = new RestRequest("/activeplayerrunes", Method.GET);
            private static RestRequest GetPlayerListRequest = new RestRequest("/playerlist", Method.GET);

            //?summonerName=
            private static RestRequest GetPlayerScoresByNameRequest = new RestRequest("/playerscores", Method.GET);
            private static RestRequest GetPlayerSummonerSpellsByNameRequest = new RestRequest("/playersummonerspells", Method.GET);
            private static RestRequest GetPlayerMainRunesByNameRequest = new RestRequest("/playermainrunes", Method.GET);
            private static RestRequest GetPlayerItemsByNameRequest = new RestRequest("/playeritems", Method.GET);

            private static RestRequest GetEventsRequest = new RestRequest("/eventdata", Method.GET);
            private static RestRequest GetGameRequest = new RestRequest("/gamestats", Method.GET);

            public async Task<string> GetActivePlayerName()
            {
                var res = await LiveClientRestClient.ExecuteAsync(GetActivePlayerNameRequest);
                //We remove the two double quotes
                return res.Content.Replace("\"", string.Empty);
            }

            public async Task<LiveClientSerializableEvent[]> GetEvents()
            {
                var res = await LiveClientRestClient.ExecuteAsync(GetEventsRequest);
                var jDoc = JsonDocument.Parse(res.Content);
                var eventsArr = jDoc.RootElement.GetProperty("Events").ToString();

                return JsonSerializer.Deserialize<LiveClientSerializableEvent[]>(eventsArr, LeagueRequestor.JsonSerializerOptions);  
            }

            public async Task<LiveClientPlayerAbilitySet> GetActivePlayerAbilities()
            {
                var res = await LiveClientRestClient.ExecuteAsync(GetActivePlayerAbilitiesRequest);
                return JsonSerializer.Deserialize<LiveClientPlayerAbilitySet>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            public async Task<LiveClientRuneSet> GetActivePlayerRunes()
            {
                var res = await LiveClientRestClient.ExecuteAsync(GetActivePlayerRunesRequest);
                return JsonSerializer.Deserialize<LiveClientRuneSet>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }
            
            public async Task<LiveClientBasicGame> GetGame()
            {
                var res = await LiveClientRestClient.ExecuteAsync(GetGameRequest);
                return JsonSerializer.Deserialize<LiveClientBasicGame>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }
            
            public async Task<LiveClientPlayerScore> GetPlayerScore(string summonerName)
            {
                GetPlayerScoresByNameRequest.AddOrUpdateParameter("summonerName", summonerName);
                var res = await LiveClientRestClient.ExecuteAsync(GetPlayerScoresByNameRequest);
                return JsonSerializer.Deserialize<LiveClientPlayerScore>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }
        
            public async Task<LiveClientSummonerSpellSet> GetPlayerSummonerSpells(string summonerName)
            {
                GetPlayerSummonerSpellsByNameRequest.AddOrUpdateParameter("summonerName", summonerName);
                var res = await LiveClientRestClient.ExecuteAsync(GetPlayerSummonerSpellsByNameRequest);
                return JsonSerializer.Deserialize<LiveClientSummonerSpellSet>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            public async Task<LiveClientMainRuneSet> GetPlayerMainRunes(string summonerName)
            {
                GetPlayerMainRunesByNameRequest.AddOrUpdateParameter("summonerName", summonerName);
                var res = await LiveClientRestClient.ExecuteAsync(GetPlayerMainRunesByNameRequest);
                return JsonSerializer.Deserialize<LiveClientMainRuneSet>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            public async Task<LiveClientItem[]> GetPlayerItems(string summonerName)
            {
                GetPlayerItemsByNameRequest.AddOrUpdateParameter("summonerName", summonerName);
                var res = await LiveClientRestClient.ExecuteAsync(GetPlayerItemsByNameRequest);
                return JsonSerializer.Deserialize<LiveClientItem[]>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }
        
            public async Task<LiveClientActivePlayer> GetActivePlayer()
            {
                var res = await LiveClientRestClient.ExecuteAsync(GetActivePlayerRequest);
                return JsonSerializer.Deserialize<LiveClientActivePlayer>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            public async Task<LiveClientPlayer[]> GetPlayers()
            {
                var res = await LiveClientRestClient.ExecuteAsync(GetPlayerListRequest);
                return JsonSerializer.Deserialize<LiveClientPlayer[]>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }
        }
    }
}
