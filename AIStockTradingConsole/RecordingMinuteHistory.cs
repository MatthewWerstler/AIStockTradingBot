using DataModels;
using MarketHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace AIStockTradingConsole
{
    public static class RecordingMinuteHistory
    {
        public static DateTime updateAllTrackedSymbolsData(HttpClient client, string apiKey, string tradeDataPath, DataModels.AllWatchLists allWatchLists)
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

            List<string> newSymbolsToTrack = watchSymbols.Where(s => !TrackedStockSymbols.Contains(s)).ToList();

            StoreNewSymbolsByMinuteData(client, apiKey, tradeDataPath, newSymbolsToTrack);

            return DateTime.Now;
        }

        private static void StoreNewSymbolsByMinuteData(HttpClient client, string apiKey, string tradeDataPath, List<string> symbols)
        {
            foreach (string symbol in symbols)
            {
                Log.write($"Updating Market Hours for Symbols {symbol}");
                try
                {
                    string newStockPath = StockHistory.Gather10daysByTheMinute(client, apiKey, symbol, tradeDataPath);
                    Log.write($"{DateTime.Now.ToString()} {symbol} minute history as been added to {newStockPath}");
                }
                catch (Exception ex)
                {
                    Log.write(ex);
                }
                Ultility.delay(250);
            }
        }

        private static void UpdateTrackedSymbolsMyMinuteData(HttpClient client, string apiKey, string tradeDataPath, List<string> TrackedStockSymbols)
        {
            foreach (string symbol in TrackedStockSymbols)
            {
                Log.write($"Updating Market Hours for Symbols {symbol}");
                string storageFolderPath = StockHistory.getSymbolsPriceHistoryPath(tradeDataPath, symbol, "ByMinute");
                List<QuoteFile> priceByMinuteFiles = ReadWriteJSONToDisk.getQuotesFileListFromDirectory(storageFolderPath);
                DateTime MaxModDate = new DateTime(0);
                if (priceByMinuteFiles.Count() > 0)
                    MaxModDate = priceByMinuteFiles.Select(s => s.info.LastWriteTime).Max();
                if (DateTime.Now.AddDays(-1) > MaxModDate)
                {
                    string newUpdatedFile = StockHistory.UpdateStockByMinuteHistoryFile(client, apiKey, symbol, tradeDataPath, true);
                    Log.write($"Symbol By Minute updated {newUpdatedFile}");
                    Ultility.delay(250);
                }
            }
        }
    }
}
