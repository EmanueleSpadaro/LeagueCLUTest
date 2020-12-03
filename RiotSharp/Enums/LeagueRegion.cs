using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Enums
{
    public enum LeagueRegion
    {
        BR1,
        EUN1,
        EUW1,
        JP1,
        KR,
        LA1,
        LA2,
        NA1,
        OC1,
        TR1
    }


    static class LeagueRegionExtension
    {
        /// <summary>
        /// The subdomain name of a given region for region-specific RiotGames API Clusters
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static string AsApiString(this LeagueRegion r)
        {
            switch (r)
            {
                case LeagueRegion.BR1:
                    {
                        return "BR1";
                    }
                case LeagueRegion.EUN1:
                    {
                        return "EUN1";
                    }
                case LeagueRegion.EUW1:
                    {
                        return "EUW1";
                    }
                case LeagueRegion.JP1:
                    {
                        return "JP1";
                    }
                case LeagueRegion.KR:
                    {
                        return "KR";
                    }
                case LeagueRegion.LA1:
                    {
                        return "LA1";
                    }
                case LeagueRegion.LA2:
                    {
                        return "LA2";
                    }
                case LeagueRegion.NA1:
                    {
                        return "NA1";
                    }
                case LeagueRegion.OC1:
                    {
                        return "OC1";
                    }
                case LeagueRegion.TR1:
                    {
                        return "TR1";
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        public static string AsString(this LeagueRegion r)
        {
            switch (r)
            {
                case LeagueRegion.BR1:
                    return "BR";
                case LeagueRegion.EUN1:
                    return "EUNE";
                case LeagueRegion.EUW1:
                    return "EUW";
                case LeagueRegion.JP1:
                    return "JP";
                case LeagueRegion.KR:
                    return "KR";
                case LeagueRegion.LA1:
                    return "LAN";
                case LeagueRegion.LA2:
                    return "LAS";
                case LeagueRegion.NA1:
                    return "NA";
                case LeagueRegion.OC1:
                    return "OCE";
                case LeagueRegion.TR1:
                    return "TR";
                default:
                    return string.Empty;
            }
        }
    }
}