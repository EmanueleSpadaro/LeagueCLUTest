using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp;
using LeagueCLUTest.RiotSharp.Enums;

using LeagueCLUTest.RiotSharp.Models;

using RestSharp;

namespace LeagueCLUTest
{
    class Program
    {
        static LeagueSharp League = new LeagueSharp();
        static RestClient RunesEndpoint = new RestClient("https://emanuelespadaro.com");

        static void Main(string[] args)
        {
            League.ChampionSelectHandler.ChampionSelected += ChampionSelectHandler_ChampionSelected;
            Console.WriteLine("Press enter to close the process");
            Console.ReadLine();
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
