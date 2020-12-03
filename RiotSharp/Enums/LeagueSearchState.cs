using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Enums
{
    /// <summary>
    /// Informs regarding a Matchmaking Queue state
    /// </summary>
    public enum LeagueSearchState
    {
        /// <summary>
        /// The matchmaking queue doesn't actually exist
        /// </summary>
        Invalid,
        /// <summary>
        /// The matchmaking queue is subject to LowPriority penalty
        /// </summary>
        AbandonedLowPriorityQueue,
        /// <summary>
        /// The Matchmaking Queue has been canceled by somebody
        /// </summary>
        Canceled,
        /// <summary>
        /// Currently searching for a game, in queue waiting for a game proposal
        /// </summary>
        Searching,
        /// <summary>
        /// Game has been proposed to the player
        /// </summary>
        Found,
        Error,
        ServiceError,
        ServiceShutdown
    }

    public static class LeagueSearchStateExtension
    {
        private static string[] PossibleValues = new string[] { "Invalid", "AbandonedLowPriorityQueue", "Canceled", "Searching", "Found", "Error", "ServiceError", "ServiceShutdown" };
        public static LeagueSearchState ToLeagueSearchState(this string s)
        {
            for (int i = 0; i < PossibleValues.Length; i++)
                if (s == PossibleValues[i])
                    return (LeagueSearchState)i;
            return default;
        }
        public static string AsString(this LeagueSearchState sState) => PossibleValues[(int)sState];

    }
}
