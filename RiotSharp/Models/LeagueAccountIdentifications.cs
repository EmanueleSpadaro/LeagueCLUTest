using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    /// <summary>
    /// Represents an AccountId & SummonerId couple that should identificate a given account
    /// </summary>
    public class LeagueAccountIdentifications
    {
        public long AccountId { get; set; }
        public long SummonerId { get; set; }
    }
}
