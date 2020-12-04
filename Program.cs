using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp;
using LeagueCLUTest.RiotSharp.Enums;

using LeagueCLUTest.RiotSharp.Models;

namespace LeagueCLUTest
{
    class Program
    {
        static LeagueSharp League = new LeagueSharp();

        static void Main(string[] args)
        { 
            var postablePerk = LeaguePostablePerkPage.FromJSON("{\"primaryStyleId\":8200,\"selectedPerkIds\":[8230,8226,8210,8237,8304,8345,5005,5008,5002],\"subStyleId\":8300,\"name\":\"[Anna.gg] Orianna\"}");

            Console.ReadKey();
            League.Requestor.Perks.ReplaceCurrentPageWith(postablePerk).Wait();
            Console.WriteLine("Press enter to check if it's blocking");
            Console.ReadKey();
            Console.WriteLine("It shouldn't be if you're here after Cycle started");
            Console.ReadKey();
        }
    }
}
