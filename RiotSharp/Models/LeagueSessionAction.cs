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

        public bool Equals(LeagueSessionAction action)
        {
            return (this.ActorCellId == action.ActorCellId && this.ChampionId == action.ChampionId
                && this.Completed == action.Completed && this.Id == action.Id
                && this.IsAllyAction == action.IsAllyAction && this.IsInProgress == action.IsInProgress
                && this.PickTurn == action.PickTurn && this.Type == action.Type);
        }
    }
}
