using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.DDragon
{
    public class DDragonImage
    {
        /// <summary>
        /// The full splashart filename
        /// </summary>
        public string Full { get; set; }
        /// <summary>
        /// The sprite filename of this champion
        /// </summary>
        public string Sprite { get; set; }
        /// <summary>
        /// The image's group (usually Champion, Item, Ability...)
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// Used for position-rendering purposes 
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Used for position-rendering purposes 
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Image width
        /// </summary>
        public int W { get; set; }
        /// <summary>
        /// Image height
        /// </summary>
        public int H { get; set; }
    }
}
