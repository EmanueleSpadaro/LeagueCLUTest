using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientItem
    {
        public bool CanUse { get; set; }
        public bool Consumable { get; set; }
        public int Count { get; set; }
        public string DisplayName { get; set; }
        public int ItemID { get; set; }
        public int Price { get; set; }
        public string RawDescription { get; set; }
        public string RawDisplayName { get; set; }
        public int Slot { get; set; }
    }
}
