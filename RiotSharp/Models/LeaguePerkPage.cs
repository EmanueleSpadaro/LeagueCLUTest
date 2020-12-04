using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeaguePerkPage : LeaguePostablePerkPage
    {
        public List<int> AutoModifiedSelections { get; set; }
        public bool Current { get; set; }
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeletable { get; set; }
        public bool IsEditable { get; set; }
        public bool IsValid { get; set; }
        public ulong LastModified { get; set; }
        public int Order { get; set; }
    }
}
