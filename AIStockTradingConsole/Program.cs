using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using MarketHistory;
using DataModels;

namespace AIStockTradingConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Load up all the setting and operating parameters
            ConsoleRunningParameters cmdParams = new ConsoleRunningParameters();
            Ultility.delay(250);

            //Get Watch lists
            var allWatchLists = AIStockTradingBotLogic.Watchlists.GetAllWatchLists(cmdParams.client);
                        
            //Saving data really only needs to happen once a day
            cmdParams.SavedAllByMinuteData = RecordingMinuteHistory.updateAllTrackedSymbolsData(cmdParams, allWatchLists);


            //-----looping section-----  "preMarket", "regularMarket", "postMarket", "outsideMarket"

            //often Call
            //TODO Check For Trades
            //TODO Check Currently Trading stocks list

            Log.write($"EndTime {DateTime.Now.ToString()}");

        }
                           
    }
}
