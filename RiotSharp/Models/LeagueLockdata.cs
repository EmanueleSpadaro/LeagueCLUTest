using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueLockData
    {
        public string ProcessName { get; private set; }
        public int ProcessID { get; private set; }
        public int Port { get; private set; }
        public string Password { get; private set; }
        public string ProtocolScheme { get; private set; }

        public LeagueLockData(string lockText)
        {
            var splitLock = lockText.Split(':');

            ProcessName = splitLock[0];
            ProcessID = Convert.ToInt32(splitLock[1]);
            Port = Convert.ToInt32(splitLock[2]);
            Password = splitLock[3];
            ProtocolScheme = splitLock[4];
        }
    }
}
