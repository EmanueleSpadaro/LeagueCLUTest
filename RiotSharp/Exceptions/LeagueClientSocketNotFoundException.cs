using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace LeagueCLUTest.RiotSharp.Exceptions
{
    public class LeagueClientSocketNotFoundException : Exception
    {
        public Process LeagueProcess { get; private set; }


        public LeagueClientSocketNotFoundException(Process LeagueProc)
            : base($"League Client has not candidate sockets to connect to.") => LeagueProcess = LeagueProc;
    }
}
