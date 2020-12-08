using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp.Models;

namespace LeagueCLUTest.RiotSharp.Handlers
{
    public class LeagueChampionSelectSessionHandlerEventArgs : EventArgs
    {
        public LeagueSession Session { get; private set; }
        public LeagueSessionAction ActionBefore { get; private set; }
        public LeagueSessionAction ActionNow { get; private set; }
        public LeagueChampionSelectSessionHandlerEventArgs(LeagueSession session, LeagueSessionAction beforeAction, LeagueSessionAction afterAction)
        {
            Session = session;
            ActionBefore = beforeAction;
            ActionNow = afterAction;
        }
    }

    public class LeagueChampionSelectSessionHandler
    {
        private LeagueSharp FatherLeagueSharp;

        /// <summary>
        /// Polling Rate in milliseconds between requests
        /// </summary>
        private const int PollingRate = 2000;

        private Task RequestorTask;

        public delegate void LeagueChampionSelectSessionUpdateHandler(object sender, LeagueChampionSelectSessionHandlerEventArgs e);
        public event LeagueChampionSelectSessionUpdateHandler SessionUpdated;

        private LeagueSession previousSession = null;

        public LeagueChampionSelectSessionHandler(LeagueSharp fatherLeagueSharp)
        {
            FatherLeagueSharp = fatherLeagueSharp;
            RequestorTask = Task.Run(RequestorTaskCycle);
        }

        private async Task RequestorTaskCycle()
        {
            while(true)
            {
                if(SessionUpdated != null)
                {
                    var session = await FatherLeagueSharp.Requestor.ChampionSelect.GetCurrentSession();
                    //We only want to manage consistent session objects
                    if (session.Actions != null)
                    {
                        if (previousSession != null && previousSession.GameId == session.GameId)
                        {
                            for (int i = 0; i < session.Actions.Length; i++)
                            {
                                var sameTypeActions = session.Actions[i];
                                var prevTypeActions = previousSession.Actions[i];
                                for (int j = 0; j < sameTypeActions.Length; j++)
                                {
                                    var currentAction = sameTypeActions[j];
                                    var previousAction = prevTypeActions[j];
                                    //If previous action differs from the other one, we throw the event
                                    if (!previousAction.Equals(currentAction))
                                        SessionUpdated(this, new LeagueChampionSelectSessionHandlerEventArgs(session, previousAction, currentAction));
                                }
                            }
                        }
                        previousSession = session;
                    }
                    else if (session.Actions == null && previousSession != null)
                        previousSession = null;
                }
                await Task.Delay(PollingRate);
            }
        }

    }
}
