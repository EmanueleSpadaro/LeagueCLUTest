using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.DDragon
{
    public class DDragonChampion
    {
        /// <summary>
        /// The version this entity of champion is up-to
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// The textual ID of this champion, it should be UNIQUE and with NO SPECIAL CHARACTERS
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The numeric ID of this champion, it's handled as a string just because it's sent as one from DDragon
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// A small title for the champion
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// A medium-length description of this champion's background 
        /// </summary>
        public string Blurb { get; set; }
        /// <summary>
        /// It contains information for the client to display properly the famous difficulty graph and so on
        /// </summary>
        public DDragonChampionInfo Info { get; set; }
        public DDragonImage Image { get; set; }
        /// <summary>
        /// A string-array containing this champion's roles (E.G. Fighter, Tank)
        /// </summary>
        public string[] Tags { get; set; }
        /// <summary>
        /// Second-bar type
        /// </summary>
        public string Partype { get; set; }
        /// <summary>
        /// Pure stats collection, it contains information like base stats and their incremental values
        /// </summary>
        public DDragonChampionStats Stats { get; set; }
    }
}
