using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientRuneSet : LiveClientMainRuneSet
    {
        /// <summary>
        /// General Runes are a combination of 4 PrimaryTree runes and 2 SecondaryTree runes
        /// </summary>
        public List<LiveClientRune> GeneralRunes { get; set; }
        /// <summary>
        /// Stat runes are object where only Id and RawDescription properties are valid
        /// </summary>
        public List<LiveClientRune> StatRunes { get; set; }
    }
}
