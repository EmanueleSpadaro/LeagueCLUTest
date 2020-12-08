using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Enums.LiveClient
{
    public enum LiveClientDragonType
    {
        Air,
        Earth,
        Fire,
        Water
    }

    public static class LiveClientDragonTypeExtension
    {
        public static LiveClientDragonType ToLiveClientDragonType(this string s)
        {
            string[] values = { "Air", "Earth", "Fire", "Water" };
            for (int i = 0; i < values.Length; i++)
                if (values[i] == s)
                    return (LiveClientDragonType)i;
            return default;
        }
    }
}
