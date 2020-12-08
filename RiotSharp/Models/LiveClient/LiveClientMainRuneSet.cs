using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientMainRuneSet
    {
        public LiveClientRune Keystone { get; set; }
        /// <summary>
        /// Primary Rune Tree
        /// </summary>
        public LiveClientRune PrimaryRuneTree { get; set; }
        /// <summary>
        /// Secondary Rune Tree
        /// </summary>
        public LiveClientRune SecondaryRuneTree { get; set; }
    }
}
