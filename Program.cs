using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using LeagueCLUTest.RiotSharp;
using LeagueCLUTest.RiotSharp.Enums;

using LeagueCLUTest.RiotSharp.Models;

using RestSharp;
using System.Threading;

namespace LeagueCLUTest
{
    class Program
    {
        static LeagueSharp League;
        static RestClient RunesEndpoint = new RestClient("https://emanuelespadaro.com");
        static void Main(string[] args)
        {
            League = new LeagueSharp();
            Console.WriteLine($"League Client patch detected: " + League.Requestor.LeaguePatch.GetGameVersionAsync().Result.ToString());
            Console.WriteLine($"League Client current username detected: " + League.Requestor.Summoner.GetCurrentSummoner().Result.DisplayName);

            //League.ChampSelectSessionHandler.SessionUpdated += ChampSelectSessionHandler_SessionUpdated; [implementare più eventi, champion pick e così via]
            Console.ReadKey();
        }
        private static void ChampSelectSessionHandler_SessionUpdated(object sender, RiotSharp.Handlers.LeagueChampionSelectSessionHandlerEventArgs e)
        {
            string stringabella = $"[#{e.ActionNow.ActorCellId}|{e.ActionNow.Type}] InProg: {e.ActionBefore.IsInProgress}->{e.ActionNow.IsInProgress}| IsComp: {e.ActionBefore.Completed}->{e.ActionNow.Completed}";
            if (e.ActionNow.Type == "pick")
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else if (e.ActionNow.Type == "ban")
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(stringabella);



            Console.WriteLine("Phase:" + e.Session.Timer.Phase);
            Console.WriteLine("GameID:" + e.Session.GameId);
        }

        private static void ChampionSelectHandler_ChampionSelected(object sender, RiotSharp.Handlers.LeagueChampionSelectHandlerEventArgs e)
        {
            var runesJson = GetRunesByEndpoint(e.ChampionID).Result;
            var rPage = League.Requestor.Perks.SetNewPageAsCurrent(runesJson).Result;
            Console.WriteLine("New runepage set to " + rPage.Name + "! Enjoy ;) ");
        }

        static async Task<LeaguePostablePerkPage> GetRunesByEndpoint(int ckid)
        {
            RestRequest RunesRequest = new RestRequest("/annaggrunes", Method.GET, DataFormat.Json);
            RunesRequest.AddParameter("ckid", ckid, ParameterType.GetOrPost);
            var res = await RunesEndpoint.ExecuteAsync(RunesRequest);

            return LeaguePostablePerkPage.FromJSON(res.Content);
        }
    }
}
