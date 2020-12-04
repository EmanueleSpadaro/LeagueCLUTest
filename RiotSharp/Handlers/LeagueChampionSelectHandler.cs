using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueCLUTest.RiotSharp.Models;

namespace LeagueCLUTest.RiotSharp.Handlers
{
    public class LeagueChampionSelectHandlerEventArgs : EventArgs
    {
        public int ChampionID { get; private set; }
        public LeagueChampionSelectHandlerEventArgs(int c) => ChampionID = c; 
    }

    public class LeagueChampionSelectHandler
    {
        private LeagueSharp FatherLeagueSharp { get; set; }
        /// <summary>
        /// Polling Rate in milliseconds between requests
        /// </summary>
        private const int PollingRate = 2000;

        private int previousChampionID = 0;

        private Task RequestorTask;

        public delegate void ChampionSelectedHandler(object sender, LeagueChampionSelectHandlerEventArgs e);
        /// <summary>
        /// Occurs when the player makes his final decision and picks a champion
        /// </summary>
        public event ChampionSelectedHandler ChampionSelected;

        public LeagueChampionSelectHandler(LeagueSharp fatherLeagueSharp)
        {
            FatherLeagueSharp = fatherLeagueSharp;
            RequestorTask = Task.Run(RequestorTaskCycle);
        }

        private async Task RequestorTaskCycle()
        {
            while(true)
            {
                if(ChampionSelected != null)
                {
                    int champID = await FatherLeagueSharp.Requestor.ChampionSelect.GetCurrentChampionID();
                    
                    if (champID != 0 && champID != previousChampionID)
                        ChampionSelected(this, new LeagueChampionSelectHandlerEventArgs(champID));

                    previousChampionID = champID;
                }

                await Task.Delay(PollingRate);
            }
        }
    }
}
