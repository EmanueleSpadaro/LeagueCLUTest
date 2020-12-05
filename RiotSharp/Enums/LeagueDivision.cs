using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Enums
{
    public enum LeagueDivision
    {
        I, II, III, IV, V, NA
    }

    public static class LeagueDivisionExtension
    {
        public static string AsString(this LeagueDivision ld)
        {
            string[] values = { "I", "II", "III", "IV", "V", "NA" };
            int i = (int)ld;
            if (i >= 0 && i < values.Length)
                return values[i];
            else
                return default;
        }

        public static LeagueDivision ToLeagueDivision(this string s)
        {
            string[] values = { "I", "II", "III", "IV", "V", "NA" };
            for (int i = 0; i < values.Length; i++)
                if (values[i] == s)
                    return (LeagueDivision)i;
            return default;
        }
    }

}
