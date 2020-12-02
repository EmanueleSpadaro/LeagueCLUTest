using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using LeagueCLUTest.RiotSharp.Enums;
using LeagueCLUTest.RiotSharp;

namespace LeagueCLUTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                LeagueSharp league = new LeagueSharp();
                bool isRdy = await league.Requestor.LeaguePatch.GetCheckingEnabledAsync();
                Console.WriteLine("LeaguePatch Checking Enabled: "  + isRdy);
            }).Wait();

            Console.ReadKey();
        }
    }
}
