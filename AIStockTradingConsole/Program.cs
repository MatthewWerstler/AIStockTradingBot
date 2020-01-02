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
            Console.WriteLine($"{DateTime.Now.ToString()} settings built");

            //Get HttpClient
            var client = new HttpClient();
            getAndSetAuthToken(client, Configuration["refresh_token"], apiKey);
            Console.WriteLine($"{DateTime.Now.ToString()} HttpClient OAuth set");

            //Get Watch lists
            var allWatchLists = AIStockTradingBotLogic.Watchlists.GetAllWatchLists(client);
            List<string> watchSymbols = new List<string>();
            foreach(var list in allWatchLists.Lists)
            {
                foreach (var item in list.watchlistItems)
                {
                    if (!watchSymbols.Contains(item.symbol))
                        watchSymbols.Add(item.symbol);
                }
            }
            Console.WriteLine($"{DateTime.Now.ToString()} Watching {watchSymbols.Count.ToString()} Symbols");
            foreach(string symbol in watchSymbols)
                Console.Write($"{symbol.PadRight(10)}");

            List<string> TrackedStockSymbols = MarketHistory.ReadWriteJSONToDisk.getListOfStocksWithHistory(tradeDataPath);
            Console.WriteLine($"{DateTime.Now.ToString()} Tracked {TrackedStockSymbols.Count.ToString()} Symbols");
            foreach (string symbol in TrackedStockSymbols)
                Console.Write($"{symbol.PadRight(10)}");

            foreach(string symbol in watchSymbols.Where(s => !TrackedStockSymbols.Contains(s)))
            {
                string newStockPath = StockHistory.Gather10daysByTheMinute(client, apiKey, symbol, tradeDataPath);
                Console.WriteLine($"{DateTime.Now.ToString()} {symbol} minute history as been added to {newStockPath}");
            }

            foreach(string symbol in TrackedStockSymbols)
            {
                string storageFolderPath = StockHistory.getSymbolsPriceHistoryPath(tradeDataPath, symbol, "ByMinute");
                List<QuoteFile> priceByMinuteFiles = ReadWriteJSONToDisk.getQuotesFileListFromDirectory(storageFolderPath);
                DateTime MaxModDate = priceByMinuteFiles.Select(s => s.info.LastWriteTime).Max();
                if(DateTime.Now.AddDays(-1) > MaxModDate)
                {
                    string newUpdatedFile = StockHistory.UpdateStockByMinuteHistoryFile(client, apiKey, symbol, tradeDataPath, true);
                    Console.WriteLine($"{DateTime.Now.ToString()} symbol By Minute updated {newUpdatedFile}");
                }
            }

            Console.WriteLine($"EndTime {DateTime.Now.ToString()}");

        }

        public static void getAndSetAuthToken(System.Net.Http.HttpClient client, string refresh_token, string Consumer_Key)
        {
            //var message = TD_API_Interface.API_Calls.Authentication.refreshToken(client, refresh_token, Consumer_Key);
            string Authorization = TD_API_Interface.API_Calls.Authentication.refreshToken(client, refresh_token, Consumer_Key);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authorization);
        }
    }
}
