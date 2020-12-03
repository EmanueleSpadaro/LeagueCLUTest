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
            League.MatchmakingHandler.MatchmakingStarted += MatchmakingHandler_MatchmakingStarted;

            Console.WriteLine("Press enter to check if it's blocking");
            Console.ReadKey();
            Console.WriteLine("It shouldn't be if you're here after Cycle started");
            Console.ReadKey();

        }

        private static void MatchmakingHandler_MatchmakingStarted(object sender, RiotSharp.Handlers.LeagueMatchmakingHandlerEventArgs e)
        {
            if (e.Matchmaking.SearchState.ToLeagueSearchState() == LeagueSearchState.Searching)
                League.Requestor.LeagueMatchmaking.DeleteSearchAsync().Wait();
            Console.WriteLine("MM started");
        }
    }
}
