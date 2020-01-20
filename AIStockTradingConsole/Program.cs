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
            Ultility.delay(475);

            //Get Watch lists
            var allWatchLists = AIStockTradingBotLogic.Watchlists.GetAllWatchLists(cmdParams.client);
            Ultility.delay(475);

            ////looping timing variables
            DateTime lastExecutionOfMinuteData = DateTime.Now.AddHours(-8);
            
            //Saving data really only needs to happen once a day
            lastExecutionOfMinuteData = RecordingMinuteHistory.updateAllTrackedSymbolsData(cmdParams.client, cmdParams.apiKey, cmdParams.tradeDataPath, allWatchLists);


            //-----looping section-----

            //often Call
            //TODO Check For Trades
            //TODO Check Currently Trading stocks list

            Log.write($"EndTime {DateTime.Now.ToString()}");

        }
                           
    }
}
