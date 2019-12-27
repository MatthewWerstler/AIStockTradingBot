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
        public static string UpdateStockByMinuteHistoryFile(HttpClient client, string apiKey, string symbol, string historyPath, bool deleteAllFilesOtherThenNewAndSourceofTruth = false)
        {
            //Get Latest by Minute data
            string newStorageFile = Gather10daysByTheMinute(client, apiKey, symbol, historyPath);
            //Get Files to Combine 
            string storageFolderPath = $"{historyPath}\\Price_History\\{symbol}\\ByMinute";
            List<QuoteFile> priceByMinuteFiles = ReadWriteJSONToDisk.getQuotesFileListFromDirectory(storageFolderPath);
            //Combine Files
            List<Quote> NewQuoteList = new List<Quote>();
            foreach(QuoteFile file in priceByMinuteFiles)
            {
                List<Quote> filesQuotes = ReadWriteJSONToDisk.getQuotesFromJSON(file.path);
                NewQuoteList = CombineQuoteLists(NewQuoteList, filesQuotes);
            }
            //write quoteList
                //Gather Start and End Date
            string minEnochDate = ((IEnumerable)NewQuoteList).Cast<dynamic>().Select(s => s.datetime).Min().ToString();
            string maxEnochDate = ((IEnumerable)NewQuoteList).Cast<dynamic>().Select(s => s.datetime).Max().ToString();
            string strMinDate = UtilityMethods.EnochToyyyyMMddhhmmString(minEnochDate);
            string strMaxDate = UtilityMethods.EnochToyyyyMMddhhmmString(maxEnochDate);
            string saveFilePath = $"{storageFolderPath}\\{strMinDate}-{strMaxDate}.json";
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

        #region "Gather Stock Price History From API"
        public static string Gather10daysByTheMinute(HttpClient client, string apiKey, string symbol, string historyPath)
        {
            //Get Data
            var results = TD_API_Interface.API_Calls.PriceHistory.getPriceHistory(client, apiKey, symbol, "day", "10", "minute", "1");
            var contents = results.Content.ReadAsStringAsync().Result;
            dynamic data = JsonConvert.DeserializeObject(contents);
            dynamic candlesData = data.candles;
            //Check save location
            string storageFolderPath = $"{historyPath}//Price_History//{symbol}//ByMinute";
            ReadWriteJSONToDisk.testCreateDirectory(storageFolderPath);
            //Gather Start and End Date
            string minEnochDate = ((IEnumerable)candlesData).Cast<dynamic>().Select(s => s.datetime).First();
            string maxEnochDate = ((IEnumerable)candlesData).Cast<dynamic>().Select(s => s.datetime).Last();
            string strMinDate = UtilityMethods.EnochToyyyyMMddhhmmString(minEnochDate);
            string strMaxDate = UtilityMethods.EnochToyyyyMMddhhmmString(maxEnochDate);
            string saveFilePath = $"{storageFolderPath}//{strMinDate}-{strMaxDate}.json";
            //save File
            ReadWriteJSONToDisk.writeDataAsJSON(saveFilePath, candlesData);
            return saveFilePath;
        }

        public static string Gather20YearsByDay(HttpClient client, string apiKey, string symbol, string historyPath)
        {
            //Get Data
            var results = TD_API_Interface.API_Calls.PriceHistory.getPriceHistory(client, apiKey, symbol, "year", "20", "daily", "1");
            var contents = results.Content.ReadAsStringAsync().Result;
            dynamic data = JsonConvert.DeserializeObject(contents);
            dynamic candlesData = data.candles;
            //Check save location
            string storageFolderPath = $"{historyPath}//Price_History//{symbol}//ByDay";
            ReadWriteJSONToDisk.testCreateDirectory(storageFolderPath);
            //Gather Start and End Date
            string minEnochDate = ((IEnumerable)candlesData).Cast<dynamic>().Select(s => s.datetime).First();
            string maxEnochDate = ((IEnumerable)candlesData).Cast<dynamic>().Select(s => s.datetime).Last();
            string strMinDate = UtilityMethods.EnochToyyyyMMddhhmmString(minEnochDate);
            string strMaxDate = UtilityMethods.EnochToyyyyMMddhhmmString(maxEnochDate);
            string saveFilePath = $"{storageFolderPath}//{strMinDate.Substring(0,8)}-{strMaxDate.Substring(0,8)}.json";
            //save File
            ReadWriteJSONToDisk.writeDataAsJSON(saveFilePath, candlesData);
            return saveFilePath;
        }
        #endregion //"Gather Stock Price History From API"

        public static List<Quote> CombineQuoteLists(List<Quote> firstQuoteList, List<Quote> sencondQuoteList)
        {
            List<DataModels.Quote> returnQuoteList = firstQuoteList.Union(sencondQuoteList, new DataModels.CompareQuoteByDatetime())
                                                                  .OrderBy(o => o.datetime)
                                                                  .ToList();
            return returnQuoteList;
        }

        public static QuoteFile ChooseSourceOfTruthFile(List<QuoteFile> files)
        {
            string firststartDate = files.Select(s => s.startDate).Min();
            List<QuoteFile> filesWithMinStartDate = files.Where(q => q.startDate == firststartDate).ToList();
            if (filesWithMinStartDate.Count == 1)
                return filesWithMinStartDate.First();
            QuoteFile returnFile = files.OrderByDescending(o => o.info.Length).First();
            return returnFile;
        }
    }
}
