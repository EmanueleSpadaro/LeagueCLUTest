using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Enums
{
    public enum LeagueRank
    {
        NONE, IRON, BRONZE, SILVER, GOLD, PLATINUM, DIAMOND, MASTER, GRANDMASTER, CHALLENGER
    }

    public static class LeagueRankExtension
    {
        public static string AsString(this LeagueRank r)
        {
            string[] values = { "NONE", "IRON", "BRONZE", "SILVER", "GOLD", "PLATINUM", "DIAMOND", "MASTER", "GRANDMASTER", "CHALLENGER" };
            int i = (int)r;
            if (i >= 0 && i < values.Length)
                return values[i];
            else
                return default;
        }

        public static LeagueRank ToLeagueRank(this string s)
        {
            string[] values = { "NONE", "IRON", "BRONZE", "SILVER", "GOLD", "PLATINUM", "DIAMOND", "MASTER", "GRANDMASTER", "CHALLENGER" };
            for (int i = 0; i < values.Length; i++)
                if (values[i] == s)
                    return (LeagueRank)i;
            return default;
        }
    }
}