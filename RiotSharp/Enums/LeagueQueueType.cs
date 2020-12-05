using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Enums
{
    public enum LeagueQueueType
    {
        NONE, RANKED_SOLO_5x5, RANKED_FLEX_SR, RANKED_FLEX_TT, RANKED_TFT
    }

    public static class LeagueQueueTypeExtension
    {
        public static string AsString(this LeagueQueueType qt)
        {
            string[] values = { "NONE", "RANKED_SOLO_5x5", "RANKED_FLEX_SR", "RANKED_FLEX_TT", "RANKED_TFT" };
            int i = (int)qt;
            if (i >= 0 && i < values.Length)
                return values[i];
            else
                return default;
        }

        public static LeagueQueueType ToLeagueQueueType(this string s)
        {
            string[] values = { "NONE", "RANKED_SOLO_5x5", "RANKED_FLEX_SR", "RANKED_FLEX_TT", "RANKED_TFT" };
            for (int i = 0; i < values.Length; i++)
                if (values[i] == s)
                    return (LeagueQueueType)i;
            return default;
        }
    }
}
