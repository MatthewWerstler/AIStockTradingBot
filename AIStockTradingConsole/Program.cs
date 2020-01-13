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
            var StartTime = DateTime.Now;
            Console.WriteLine($"StartTime {StartTime.ToString()}");

            //Get Secrete
            var builder = new ConfigurationBuilder()
                            .AddUserSecrets<Program>();
            IConfiguration Configuration = builder.Build();
            string apiKey = Configuration["Consumer_Key"];
            string _account01 = Configuration["Account01"];
            string tradeDataPath = Configuration["TradingDataPath"];
            Log.write($"settings built");

            //Get HttpClient
            var client = new HttpClient();
            getAndSetAuthToken(client, Configuration["refresh_token"], apiKey);
            Log.write($"HttpClient OAuth set");

            //Get Watch lists
            var allWatchLists = AIStockTradingBotLogic.Watchlists.GetAllWatchLists(client);

            //looping timing variables
            DateTime lastExecutionOfMinuteData = DateTime.Now.AddHours(-8);

            //-----looping section-----
            
            //often Call
            //TODO Check For Trades
            //TODO Check Currently Trading stocks list

            //Saving data really only needs to happen once a day
            lastExecutionOfMinuteData = getByMinuteUpdate(client, apiKey, tradeDataPath, allWatchLists);


            Log.write($"EndTime {DateTime.Now.ToString()}");

        }

        public static void getAndSetAuthToken(System.Net.Http.HttpClient client, string refresh_token, string Consumer_Key)
        {
            //var message = TD_API_Interface.API_Calls.Authentication.refreshToken(client, refresh_token, Consumer_Key);
            string Authorization = TD_API_Interface.API_Calls.Authentication.refreshToken(client, refresh_token, Consumer_Key);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authorization);
        }

        private static void delay(int Time_delay)
        {
            int i = 0;
            var _delayTimer = new System.Timers.Timer();
            _delayTimer.Interval = Time_delay;
            _delayTimer.AutoReset = false; //so that it only calls the method once
            _delayTimer.Elapsed += (s, args) => i = 1;
            _delayTimer.Start();
            while (i == 0) { };
        }

        private static DateTime getByMinuteUpdate(HttpClient client, string apiKey, string tradeDataPath, DataModels.AllWatchLists allWatchLists)
        {

            List<string> watchSymbols = new List<string>();
            foreach (var list in allWatchLists.Lists)
            {
                foreach (var item in list.watchlistItems)
                {
                    if (!watchSymbols.Contains(item.symbol) && !item.symbol.Contains("/") && item.assetType == "EQUITY")
                        watchSymbols.Add(item.symbol);
                }
            }
            Log.write($"{DateTime.Now.ToString()} Watching {watchSymbols.Count.ToString()} Symbols");
            foreach (string symbol in watchSymbols)
                Console.Write($"{symbol.PadRight(10)}");

            Log.write($"{watchSymbols.Count.ToString()} valid symbols found within {allWatchLists.Lists.Count.ToString()} watch lists.");

            int countTrackedStockSymbols = 0;
            List<string> TrackedStockSymbols = MarketHistory.ReadWriteJSONToDisk.getListOfStocksWithHistory(tradeDataPath);
            Log.write($"{DateTime.Now.ToString()} Tracked {TrackedStockSymbols.Count.ToString()} Symbols");
            foreach (string symbol in TrackedStockSymbols)
            {
                Console.Write($"{symbol.PadRight(10)}");
                countTrackedStockSymbols++;
            }
            Console.WriteLine("");

            foreach (string symbol in watchSymbols.Where(s => !TrackedStockSymbols.Contains(s)))
            {
                Log.write($"Processing {symbol}");
                try
                {
                    string newStockPath = StockHistory.Gather10daysByTheMinute(client, apiKey, symbol, tradeDataPath);
                    Log.write($"{DateTime.Now.ToString()} {symbol} minute history as been added to {newStockPath}");
                }
                catch (Exception ex)
                {
                    Log.write(ex);
                }
                delay(450);
            }

            foreach (string symbol in TrackedStockSymbols)
            {
                string storageFolderPath = StockHistory.getSymbolsPriceHistoryPath(tradeDataPath, symbol, "ByMinute");
                List<QuoteFile> priceByMinuteFiles = ReadWriteJSONToDisk.getQuotesFileListFromDirectory(storageFolderPath);
                DateTime MaxModDate = new DateTime(0);
                if (priceByMinuteFiles.Count() > 0)
                    MaxModDate = priceByMinuteFiles.Select(s => s.info.LastWriteTime).Max();
                if (DateTime.Now.AddDays(-1) > MaxModDate)
                {
                    string newUpdatedFile = StockHistory.UpdateStockByMinuteHistoryFile(client, apiKey, symbol, tradeDataPath, true);
                    Log.write($"{DateTime.Now.ToString()} symbol By Minute updated {newUpdatedFile}");
                    delay(450);
                }
            }
            return DateTime.Now;
        }
    }
}
