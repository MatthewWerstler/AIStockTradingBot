using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD_API_Interface;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using MarketHistory;

namespace WorkingMansDayTradingTests.MarketHistory
{
    [TestClass]
    public class TestStockHistory
    {

        WorkingMansDayTradingTests.TDAmeritradeInterface.HttpClientHelper testingHttpClient;

        [TestInitialize]
        public void Setup()
        {
            testingHttpClient = new WorkingMansDayTradingTests.TDAmeritradeInterface.HttpClientHelper();
        }
        [TestCleanup]
        public void Dispose()
        {
            testingHttpClient.Dispose();
        }

        public List<string> stockList = new List<string>(new string[] { "HRZN", "NRZ", "PSEC", "MAIN", "GOOD", "GAIN", "CIF", "EFC" });

        [TestMethod]
        public void testWritingMinuteStockPriceHistoryToJSONFiles()
        {
            foreach(string symbol in stockList)
            { 
                string filepath = StockHistory.Gather10daysByTheMinute(testingHttpClient.client, testingHttpClient.apiKey, symbol, testingHttpClient.path);
                Assert.IsTrue(File.Exists(filepath));
                System.Threading.Thread.Sleep(500);
            }
        }

        [TestMethod]
        public void testWritingDailyStockPriceHistoryToJSONFiles()
        {
            foreach (string symbol in stockList)
            {
                string filepath = StockHistory.Gather20YearsByDay(testingHttpClient.client, testingHttpClient.apiKey, symbol, testingHttpClient.path);
                Assert.IsTrue(File.Exists(filepath));
            }
        }
    }
}
