using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Enums
{
    /// <summary>
    /// Informs regarding a player choice towards a game proposal
    /// </summary>
    public enum LeaguePlayerResponse
    {
        /// <summary>
        /// The player hasn't made a decision yet
        /// </summary>
        None,
        /// <summary>
        /// The player has accepted the game
        /// </summary>
        Accepted,
        /// <summary>
        /// The player has declined the game
        /// </summary>
        Declined
    }

    public static class LeaguePlayerResponseExtension
    {
        private static string[] PossibleValues = new string[] { "Invalid", "AbandonedLowPriorityQueue", "Canceled", "Searching", "Found", "Error", "ServiceError", "ServiceShutdown" };
        public static LeaguePlayerResponse ToLeaguePlayerResponse(this string s)
        {
            for (int i = 0; i < PossibleValues.Length; i++)
                if (s == PossibleValues[i])
                    return (LeaguePlayerResponse)i;
            return default;
        }
        public static string AsString(this LeagueSearchState sState) => PossibleValues[(int)sState];

    }
}
