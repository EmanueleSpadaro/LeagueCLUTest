using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp;
using LeagueCLUTest.RiotSharp.Enums;

namespace LeagueCLUTest
{
    class Program
    {
        static LeagueSharp League = new LeagueSharp();

        static void Main(string[] args)
        {
            League.ChampionSelectHandler.ChampionSelected += ChampionSelectHandler_ChampionSelected;

            Console.WriteLine("Press enter to check if it's blocking");
            Console.ReadKey();
            Console.WriteLine("It shouldn't be if you're here after Cycle started");
            Console.ReadKey();

        }

        private static void ChampionSelectHandler_ChampionSelected(object sender, RiotSharp.Handlers.LeagueChampionSelectHandlerEventArgs e)
        {
            Console.WriteLine("Selected ChampID: " + e.ChampionID);
        }
    }
}
