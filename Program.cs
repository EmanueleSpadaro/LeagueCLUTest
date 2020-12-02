using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp;

namespace LeagueCLUTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var league = new LeagueSharp();

            int x = league.Requestor.RiotClient.GetAppPort().Result;

            var gVer = league.Requestor.LeaguePatch.GetGameVersionAsync().Result;

            var patchStatus = league.Requestor.LeaguePatch.GetStatusAsync().Result;

            Console.WriteLine(x);
            Console.WriteLine(gVer.ToString());
            Console.WriteLine(patchStatus.ToString());

            Console.ReadKey();

        }
    }
}
