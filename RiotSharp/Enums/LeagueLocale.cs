using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Enums
{
    public enum LeagueLocale
    {
        csCZ,
        elGR,
        plPL,
        roRO,
        huHU,
        enGB,
        deDE,
        esES,
        itIT,
        frFR,
        jaJP,
        koKR,
        esMX,
        esAR,
        ptBR,
        enUS,
        enAU,
        ruRU,
        trTR,
        msMY,
        enPH,
        enSG,
        thTH,
        vnVN,
        idID,
        zhMY,
        zhCN,
        zhTW
    }


    static class LeagueLocaleExtension
    {
        public static string AsString(this LeagueLocale locale)
        {
            switch (locale)
            {
                case LeagueLocale.csCZ:
                    {
                        return "cs_CZ";
                    }
                case LeagueLocale.elGR:
                    {
                        return "el_GR";
                    }
                case LeagueLocale.plPL:
                    {
                        return "pl_PL";
                    }
                case LeagueLocale.roRO:
                    {
                        return "ro_RO";
                    }
                case LeagueLocale.huHU:
                    {
                        return "hu_HU";
                    }
                case LeagueLocale.enGB:
                    {
                        return "en_GB";
                    }
                case LeagueLocale.deDE:
                    {
                        return "de_DE";
                    }
                case LeagueLocale.esES:
                    {
                        return "es_ES";
                    }
                case LeagueLocale.itIT:
                    {
                        return "it_IT";
                    }
                case LeagueLocale.frFR:
                    {
                        return "fr_FR";
                    }
                case LeagueLocale.jaJP:
                    {
                        return "ja_JP";
                    }
                case LeagueLocale.koKR:
                    {
                        return "ko_KR";
                    }
                case LeagueLocale.esMX:
                    {
                        return "es_MX";
                    }
                case LeagueLocale.esAR:
                    {
                        return "es_AR";
                    }
                case LeagueLocale.ptBR:
                    {
                        return "pt_BR";
                    }
                case LeagueLocale.enUS:
                    {
                        return "en_US";
                    }
                case LeagueLocale.enAU:
                    {
                        return "en_AU";
                    }
                case LeagueLocale.ruRU:
                    {
                        return "ru_RU";
                    }
                case LeagueLocale.trTR:
                    {
                        return "tr_TR";
                    }
                case LeagueLocale.msMY:
                    {
                        return "ms_MY";
                    }
                case LeagueLocale.enPH:
                    {
                        return "en_PH";
                    }
                case LeagueLocale.enSG:
                    {
                        return "en_SG";
                    }
                case LeagueLocale.thTH:
                    {
                        return "th_TH";
                    }
                case LeagueLocale.vnVN:
                    {
                        return "vnVN";
                    }
                case LeagueLocale.idID:
                    {
                        return "id_ID";
                    }
                case LeagueLocale.zhMY:
                    {
                        return "zh_MY";
                    }
                case LeagueLocale.zhCN:
                    {
                        return "zh_CN";
                    }
                case LeagueLocale.zhTW:
                    {
                        return "zh_TW";
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        public static LeagueLocale ToLeagueLocale(this string s)
        {
            //We run all over our Enum possible values
            for(int i = 0; i < (int)LeagueLocale.zhTW; i++)
            {
                LeagueLocale locale = (LeagueLocale)i;
                if (locale.AsString() == s)
                    return locale;
            }
            return default;
        }
    }
}