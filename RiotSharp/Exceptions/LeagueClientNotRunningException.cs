using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Exceptions
{
    public class LeagueClientNotRunningException : Exception
    {
        public string ExecutableName { get; private set; }
        public LeagueClientNotRunningException(string execName)
            : base($"Unable to find {execName} process") => this.ExecutableName = execName;
    }
}
