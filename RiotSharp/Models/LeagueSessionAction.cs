using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueSessionAction
    {
        public int ActorCellId { get; set; }
        public int ChampionId { get; set; }
        public bool Completed { get; set; }
        public int Id { get; set; }
        public bool IsAllyAction { get; set; }
        public bool IsInProgress { get; set; }
        public int PickTurn { get; set; }
        public string Type { get; set; }
    }
}
