using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueChampion
    {
        /// <summary>
        /// This is the game version of this Champion
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// This is the string unique id of the champion E.G. [(Nunu & Willump)Champ name != Champ ID (Nunu)]
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Numeric champion identifier
        /// </summary>
        public int Key { get; set; }

    }
}
