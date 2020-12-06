using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueSessionSummoner
    {
        public string AssignedPosition { get; set; }
        public int CellId { get; set; }
        public int ChampionId { get; set; }
        public int ChampionPickIntent { get; set; }
        public string EntitledFeatureType { get; set; }
        public int SelectedSkinId { get; set; }
        public int Spell1Id { get; set; }
        public int Spell2Id { get; set; }
        public int SummonerId { get; set; }
        public int Team { get; set; }
        public int WardSkinId { get; set; }
    }
}
