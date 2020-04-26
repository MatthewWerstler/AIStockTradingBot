using System;
using System.Collections;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using DataModels;
using System.Collections.Generic;

namespace MarketHistory
{
    public static class StockHistory
    {

        #region "Gather Stock Price History From API"

        /// <summary>
        /// This gathers the last Ten Days of a Symbol Price History by minute and combines it with previously stored data.
        /// It rights the combined results to the TradeData folder
        /// </summary>
        /// <param name="client">HttpClient with OAuth Header</param>
        /// <param name="apiKey">TDAmeritrade API Application Key</param>
        /// <param name="symbol">Market (Stock) Symbol Case Sensitive</param>
        /// <param name="historyPath">Program Data Path (Configurable)</param>
        /// <param name="deleteAllFilesOtherThenNewAndSourceofTruth">If true after combining all the data files 
        /// attempt to delete all the files except for the previously source of true and the newly combined price history.
        /// Unfortunately if there are not new updates to the price history it deletes all previous sources of truth</param>
        /// <returns>The new combined file path</returns>
        public static string UpdateStockByMinuteHistoryFile(HttpClient client, string apiKey, string symbol, string historyPath, bool deleteAllFilesOtherThenNewAndSourceofTruth = false)
        {
            //Get Latest by Minute data
            string newStorageFile = Gather10daysByTheMinute(client, apiKey, symbol, historyPath);
            //Get Files to Combine 
            string storageFolderPath = getSymbolsPriceHistoryPath(historyPath, symbol, "ByMinute");
            List<QuoteFile> priceByMinuteFiles = ReadWriteJSONToDisk.getQuotesFileListFromDirectory(storageFolderPath);
            //Combine Files
            List<Quote> NewQuoteList = new List<Quote>();
            foreach(QuoteFile file in priceByMinuteFiles)
            {
                List<Quote> filesQuotes = ReadWriteJSONToDisk.getQuotesFromJSON(file.path);
                NewQuoteList = CombineQuoteLists(NewQuoteList, filesQuotes);
            }
            //write quoteList
            string quoteFileName = getFileNameForPriceHistory(NewQuoteList, true);
            string saveFilePath = $"{storageFolderPath}\\{quoteFileName}";
                //save File
            ReadWriteJSONToDisk.writeDataAsJSON(saveFilePath, NewQuoteList);
            //delete old files
            if(deleteAllFilesOtherThenNewAndSourceofTruth)
            {
                QuoteFile oldSourceOfTruth = ChooseSourceOfTruthFile(priceByMinuteFiles);
                List<QuoteFile> filesToDelete = priceByMinuteFiles.Where(q => q.info.Name != oldSourceOfTruth.info.Name).ToList();
                int filesDeleted = ReadWriteJSONToDisk.deleteFiles(filesToDelete);
            }
            //return new file path
            return saveFilePath;
        }

        /// <summary>
        /// Gathers the last 10 days of price history for a symbol and saves it to a json file
        /// </summary>
        /// <param name="client">HttpClient with OAuth Header</param>
        /// <param name="apiKey">TDAmeritrade API Application Key</param>
        /// <param name="symbol">Market (Stock) Symbol Case Sensitive</param>
        /// <param name="historyPath">Program Data Path (Configurable)</param>
        /// <returns>The new combined file path</returns>
        public static string Gather10daysByTheMinute(HttpClient client, string apiKey, string symbol, string historyPath)
        {
            //Get Data
            var results = TD_API_Interface.API_Calls.PriceHistory.getPriceHistory(client, apiKey, symbol, "day", "10", "minute", "1");
            var contents = results.Content.ReadAsStringAsync().Result;
            dynamic data = JsonConvert.DeserializeObject(contents);
            dynamic candlesData = data.candles;
            if(candlesData.Count > 0)
            { 
                //Check save location
                string storageFolderPath = getSymbolsPriceHistoryPath(historyPath, symbol, "ByMinute");
                ReadWriteJSONToDisk.testCreateDirectory(storageFolderPath);
                //Gather Start and End Date
                string quoteFileName = getFileNameForPriceHistory(candlesData, true);
                string saveFilePath = $"{storageFolderPath}\\{quoteFileName}";
                //save File
                ReadWriteJSONToDisk.writeDataAsJSON(saveFilePath, candlesData);
                return saveFilePath;
            }
            else
            {
                return "No data returned";
            }
        }

        /// <summary>
        /// Gathers up to 20 years of a symbols price history by day, and stores it to a json file
        /// </summary>
        /// <param name="client">HttpClient with OAuth Header</param>
        /// <param name="apiKey">TDAmeritrade API Application Key</param>
        /// <param name="symbol">Market (Stock) Symbol Case Sensitive</param>
        /// <param name="historyPath">Program Data Path (Configurable)</param>
        /// <returns>The new combined file path</returns>
        public static string Gather20YearsByDay(HttpClient client, string apiKey, string symbol, string historyPath)
        {
            //Get Data
            var results = TD_API_Interface.API_Calls.PriceHistory.getPriceHistory(client, apiKey, symbol, "year", "20", "daily", "1");
            var contents = results.Content.ReadAsStringAsync().Result;
            dynamic data = JsonConvert.DeserializeObject(contents);
            dynamic candlesData = data.candles;
            if (candlesData.Count > 0)
            {
                //Check save location
                string storageFolderPath = getSymbolsPriceHistoryPath(historyPath, symbol, "ByDay");
                ReadWriteJSONToDisk.testCreateDirectory(storageFolderPath);
                //Gather Start and End Date
                string quoteFileName = getFileNameForPriceHistory(candlesData, false);
                string saveFilePath = $"{storageFolderPath}//{quoteFileName}";
                //save File
                ReadWriteJSONToDisk.writeDataAsJSON(saveFilePath, candlesData);
                return saveFilePath;
            }
            else
            {
                return "No data returned";
            }
        }
        #endregion //"Gather Stock Price History From API"

        /// <summary>
        /// Combines two Lists of Quote.  Used to build history.
        /// These should alway be quotes for the same symbol at the same frequency
        /// </summary>
        /// <param name="firstQuoteList">symbol Quote List</param>
        /// <param name="secondQuoteList">symbol Quote List</param>
        /// <returns></returns>
        public static List<Quote> CombineQuoteLists(List<Quote> firstQuoteList, List<Quote> secondQuoteList)
        {
            if (secondQuoteList != null)
            {
                List<DataModels.Quote> returnQuoteList = firstQuoteList.Union(secondQuoteList, new DataModels.CompareQuoteByDatetime())
                                                                      .OrderBy(o => o.datetime)
                                                                      .ToList();
                return returnQuoteList;
            }
            else
            {
                return firstQuoteList;
            }
        }

        /// <summary>
        /// Attempts to pick the file that goes back the farthest and contains the most data from a list of QuoteFiles
        /// </summary>
        /// <param name="files">Quote Files (pertaining to a specific symbol at a specific frequency</param>
        /// <returns></returns>
        public static QuoteFile ChooseSourceOfTruthFile(List<QuoteFile> files)
        {
            string firststartDate = files.Select(s => s.startDate).Min();
            List<QuoteFile> filesWithMinStartDate = files.Where(q => q.startDate == firststartDate).ToList();
            if (filesWithMinStartDate.Count == 1)
                return filesWithMinStartDate.First();
            QuoteFile returnFile = files.OrderByDescending(o => o.info.Length).First();
            return returnFile;
        }

        /// <summary>
        /// Gets a Storage Path For Specific Price History
        /// </summary>
        /// <param name="dataTradeDataPath">Trade Data Folder On This Machine</param>
        /// <param name="symbol">Ticket Stock Symbol Case Sensitive</param>
        /// <param name="QuoteFrequency">(ByMinute, ByDay)Price History Quote Frequency </param>
        /// <returns>Path to save price quotes for specific stock</returns>
        public static string getSymbolsPriceHistoryPath(string dataTradeDataPath, string symbol, string QuoteFrequency)
        {
            return $"{dataTradeDataPath}\\Price_History\\{symbol}\\{QuoteFrequency}";
        }

        /// <summary>
        /// Get file name for collection of dynamic PriceHistory Data
        /// </summary>
        /// <param name="PriceHistoryData">dynamic Price History Data direct for TDA</param>
        /// <param name="isByMinute">Is by minute true of false</param>
        /// <returns>file name to save as</returns>
        public static string getFileNameForPriceHistory(dynamic candlesData, bool isByMinute)
        {
            string minEnochDate = ((IEnumerable)candlesData).Cast<dynamic>().Select(s => s.datetime).First();
            string maxEnochDate = ((IEnumerable)candlesData).Cast<dynamic>().Select(s => s.datetime).Last();
            string strMinDate = UtilityMethods.EnochToyyyyMMddhhmmString(minEnochDate);
            string strMaxDate = UtilityMethods.EnochToyyyyMMddhhmmString(maxEnochDate);
            if(isByMinute)
                return $"{strMinDate}-{strMaxDate}.json";
            else
                return $"{strMinDate.Substring(0, 8)}-{strMaxDate.Substring(0, 8)}.json";
        }

        /// <summary>
        /// Get file name for collection of List<Quote> PriceHistory Data
        /// </summary>
        /// <param name="PriceHistoryData">dynamic Price History Data direct for TDA</param>
        /// <param name="isByMinute">Is by minute true of false</param>
        /// <returns>file name to save as</returns>
        public static string getFileNameForPriceHistory(List<Quote> QuoteData, bool isByMinute)
        {
            string minEnochDate = ((IEnumerable)QuoteData).Cast<dynamic>().Select(s => s.datetime).Min().ToString();
            string maxEnochDate = ((IEnumerable)QuoteData).Cast<dynamic>().Select(s => s.datetime).Max().ToString();
            string strMinDate = UtilityMethods.EnochToyyyyMMddhhmmString(minEnochDate);
            string strMaxDate = UtilityMethods.EnochToyyyyMMddhhmmString(maxEnochDate);
            if (isByMinute)
                return $"{strMinDate}-{strMaxDate}.json";
            else
                return $"{strMinDate.Substring(0, 8)}-{strMaxDate.Substring(0, 8)}.json";
        }
    }
}
