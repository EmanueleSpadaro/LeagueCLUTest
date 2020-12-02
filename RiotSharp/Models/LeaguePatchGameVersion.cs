using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeaguePatchGameVersion
    {
        /// <summary>
        /// Patch's season
        /// </summary>
        public int Season { get; private set; }
        
        /// <summary>
        /// Patch's major, this is basically the number that players use to refer to champion buffs and/or nerfs
        /// </summary>
        public int Major { get; private set; }

        /// <summary>
        /// Patch's minor
        /// </summary>
        public int Minor { get; private set; }

        public LeaguePatchGameVersion(string patchStr)
        {
            var regResult = Regex.Match(patchStr, @"(\d+)");
            Season = Convert.ToInt32(regResult.Groups[0]);
            Major = Convert.ToInt32(regResult.Groups[1]);
            Minor = Convert.ToInt32(regResult.Groups[2]);
        }

        public bool Equals(LeaguePatchGameVersion v)
            => this.Season == v.Season && this.Major == v.Major;
    }
}
