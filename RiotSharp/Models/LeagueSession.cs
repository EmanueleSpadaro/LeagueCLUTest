using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeagueSession
    {
        public LeagueSessionAction[][] Actions { get; set; }
        public bool AllowBattleBoost { get; set; }
        public bool AllowDuplicatePicks { get; set; }
        public bool AllowLockedEvents { get; set; }
        public bool AllowRerolling { get; set; }
        public bool AllowSkinSelection { get; set; }
        public LeagueSessionBanCollection Bans { get; set; }
        public List<int> BenchChampionIds { get; set; }
        public bool BenchEnabled { get; set; }
        public int BoostableSkinCount { get; set; }
        public LeagueSessionChatDetails ChatDetails { get; set; }
        public int Counter { get; set; }
        public LeagueSessionFeatureState EntitledFeatureState { get; set; }
        public long GameId { get; set; }
        public bool HasSimultaneousBans { get; set; }
        public bool HasSimultaneousPicks { get; set; }
        public bool IsCustomGame { get; set; }
        public bool IsSpectating { get; set; }
        public int LocalPlayerCellId { get; set; }
        public int LockedEventIndex { get; set; }
        public LeagueSessionSummoner[] MyTeam { get; set; }
        public int RerollsRemaining { get; set; }
        public bool SkipChampionSelect { get; set; }
        public LeagueSessionSummoner[] TheirTeam { get; set; }
        public LeagueChampionSelectTimer Timer { get; set; }
        public List<int> Trades { get; set; }

        //RiotSharp additions

        public LeagueSessionAction[] ActionsReliable { get => this.Actions[0]; }
        public int PlayersCount { get => MyTeam.Length + TheirTeam.Length; }
    }
}
