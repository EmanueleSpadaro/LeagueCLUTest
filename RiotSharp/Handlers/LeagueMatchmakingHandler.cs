using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp.Enums;
using LeagueCLUTest.RiotSharp.Models;

using RestSharp;

namespace LeagueCLUTest.RiotSharp.Handlers
{
    public class LeagueMatchmakingHandlerEventArgs : EventArgs
    {
        public LeagueMatchmaking Matchmaking { get; private set; }

        public LeagueMatchmakingHandlerEventArgs(LeagueMatchmaking m)
        {
            Matchmaking = m;
        }
    }

    public class LeagueMatchmakingHandler
    {
        private LeagueSharp FatherLeagueSharp { get; set; }

        /// <summary>
        /// Polling Rate in milliseconds between requests
        /// </summary>
        private const int PollingRate = 1500;

        private Task RequestorTask;

        /// <summary>
        /// Contains the previous queue time obtain by LeagueMatchmakingRequest, it's used to check whether the requestor obtain a new queue and must call the event
        /// </summary>
        private double PreviousQueueTime = double.PositiveInfinity;

        public delegate void MatchmakingStartedHandler(object sender, LeagueMatchmakingHandlerEventArgs e);
        public event MatchmakingStartedHandler MatchmakingStarted;

        public LeagueMatchmakingHandler(LeagueSharp fatherLeagueSharp)
        {
            FatherLeagueSharp = fatherLeagueSharp;
            RequestorTask = Task.Run(RequestorTaskCycle);
        }

        private async Task RequestorTaskCycle()
        {
            while (true)
            {
                if (MatchmakingStarted != null)
                {
                    var mm = await FatherLeagueSharp.Requestor.LeagueMatchmaking.GetSearchAsync();
                    if (mm.IsCurrentlyInQueue && mm.SearchState.ToLeagueSearchState() == LeagueSearchState.Searching)
                    {
                        //If PreviousQueueTime is less or equal to the recent TimeInQueue we assume it's the same event and therefore we don't throw any event
                        if (PreviousQueueTime <= mm.TimeInQueue)
                        {

                        }
                        else //We assume it's a new one
                        {
                            OnMatchmakingStarted(mm);
                        }
                        PreviousQueueTime = mm.TimeInQueue;
                    }
                }
                await Task.Delay(PollingRate);
            }
        }

        protected virtual void OnMatchmakingStarted(LeagueMatchmaking mm)
        {
            MatchmakingStarted?.Invoke(this, new LeagueMatchmakingHandlerEventArgs(mm));
        }
    }
}
