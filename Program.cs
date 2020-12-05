﻿using System;
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
            var sByName = League.Requestor.Summoner.GetSummoner("Markown").Result;
            Console.WriteLine(sByName.InternalName);
            var markuhRegalia = League.Requestor.Regalia.GetSummonerRegalia(sByName).Result;
            Console.ReadKey();
            /*
            Console.WriteLine("====================== Anna.gg (not for much time, sadly) ======================");
            Console.WriteLine("Waiting for LeagueClient...");
            while (Process.GetProcessesByName("LeagueClient").Length == 0)
                Thread.Sleep(1000);
            Thread.Sleep(1000);
            Console.WriteLine("Loading... 0%");
            Thread.Sleep(1000);
            Console.WriteLine("Loading... 25%");
            Thread.Sleep(1000);
            Console.WriteLine("Loading... 50%");
            Thread.Sleep(1000);
            Console.WriteLine("Loading... 75%");
            Thread.Sleep(1000);
            Console.WriteLine("Loading... 100%");
            Thread.Sleep(500);
            Console.Clear();
            try
            {
                League = new LeagueSharp();
            }
            catch
            {
                return;
            }
            //Correctly connected to LCU from now on
            League.ChampionSelectHandler.ChampionSelected += ChampionSelectHandler_ChampionSelected;

            Console.WriteLine("====================== Anna.gg (not for much time, sadly) ======================");
            Console.WriteLine("Welcome! Relax and chill while I'll take care of everything regarding your runes :)");
            Console.WriteLine("How to use me? You don't use me, bastard. I'm just trying to help you here.");
            Console.WriteLine("You just have to play League however you've always done and when you'll pick a champ\nI'll bake a fresh new rune page for it");
            Console.WriteLine("Take your seat and hang tight, leave ");
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            */
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
