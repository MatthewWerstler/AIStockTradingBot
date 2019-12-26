using System;
using System.Collections;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace MarketHistory
{
    public static class StockHistory
    {
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
    }
}
