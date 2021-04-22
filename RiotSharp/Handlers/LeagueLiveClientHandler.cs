using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Handlers
{
    public class LeagueLiveClientHandler
    {
        private LeagueSharp FatherLeagueSharp { get; set; }
        /// <summary>
        /// Polling Rate in milliseconds between requests
        /// </summary>
        private const int PollingRate = 2000;

        private Task RequestorTask;

        private bool IsNewGame = true;
        private bool HasRaisedEndedEvent = true;

        private int LastEventID = -1;

        public LeagueLiveClientHandler(LeagueSharp fatherLeagueSharp)
        {
            FatherLeagueSharp = fatherLeagueSharp;
            RequestorTask = Task.Run(RequestorTaskCycle);
        }

        private async Task RequestorTaskCycle()
        {
            while (true)
            {
                //We check if there's a live game currently running on the machine
                if(await CheckLiveClientAvailability())
                {
                    //We check with our internal flags whether it's a new game or it's the same we've been fetching previously
                    if (IsNewGame)
                    {
                        //We throw the "new game" event
                        Console.WriteLine("NewLiveGameStarted");
                        IsNewGame = false;
                        HasRaisedEndedEvent = false;
                    }

                    var events = await FatherLeagueSharp.Requestor.LiveClient.GetEvents();
                    if(events[events.Length-1].EventID > LastEventID)
                    {
                        //We raise an event for every new event since the previous polling request
                        for(int i = LastEventID + 1; i < events.Length; i++)
                            Console.WriteLine(events[i].EventName + " #" + events[i].EventID);
                        LastEventID = events[events.Length - 1].EventID;
                    }
                }
                else
                {
                    IsNewGame = true;
                    if(!HasRaisedEndedEvent)
                    {
                        Console.WriteLine("Raising ended event");
                        HasRaisedEndedEvent = true;
                        LastEventID = -1;
                    }
                }
                await Task.Delay(PollingRate);
            }
        }

        private async Task<bool> CheckLiveClientAvailability()
        {
            if (Process.GetProcessesByName("League of Legends").Length > 0)
            {
                string pName = await FatherLeagueSharp.Requestor.LiveClient.GetActivePlayerName();
                return !string.IsNullOrEmpty(pName) && !pName.Contains("httpStatus: 404,");
            }
            else
                return false;
        }
    }
}
