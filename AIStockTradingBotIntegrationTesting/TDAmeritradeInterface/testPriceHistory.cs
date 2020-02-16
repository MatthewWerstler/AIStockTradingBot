using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD_API_Interface;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;
using System.Collections;

namespace WorkingMansDayTradingTests.TDAmeritradeInterface
{
    [TestClass]
    public class testPriceHistory
    {
        WorkingMansDayTradingTests.TDAmeritradeInterface.HttpClientHelper testingHttpClient;
        [TestInitialize]
        public void Setup()
        {
            testingHttpClient = new TDAmeritradeInterface.HttpClientHelper();
        }
        [TestCleanup]
        public void Dispose()
        {
            testingHttpClient.Dispose();
        }

        /// <summary>
        /// Initial Price History Test there are alot of options, 
        /// and there will be a need for wrapper functions.  
        /// A lot of testing needs done there but this is just enough for me to continue mapping other API calls
        /// </summary>
        [TestMethod]
        public void testBasicPriceHistoryCall()
        {
            var results = TD_API_Interface.API_Calls.PriceHistory.getPriceHistory(testingHttpClient.client, testingHttpClient.apiKey, "GAIN", "ytd", "1", "daily", "1");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);
        }
        [TestMethod]
        public void testGettingStockPricesByTheMinute()
        {
            var results = TD_API_Interface.API_Calls.PriceHistory.getPriceHistory(testingHttpClient.client, testingHttpClient.apiKey, "MSFT", "day", "10", "minute", "1");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 3);
            //I find it interesting the leaving out the day and 10 returns seems to return the results as putting it in.  The kind folks at TDA told me data is capped at 20 days.  However I can not seem to get more then 10 business days.
            results = TD_API_Interface.API_Calls.PriceHistory.getPriceHistory(testingHttpClient.client, testingHttpClient.apiKey, "MSFT", "", "", "minute", "1");
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(contents.Length > 3);
            dynamic data = JsonConvert.DeserializeObject(contents);
            dynamic candlesData = data.candles;
            string maxDate = ((IEnumerable)candlesData).Cast<dynamic>().Select(s => s.datetime).Max();
            Assert.IsNotNull(maxDate);
        }

        [TestMethod]
        public void testGettingDailyStockValues()
        {
            var results = TD_API_Interface.API_Calls.PriceHistory.getPriceHistory(testingHttpClient.client, testingHttpClient.apiKey, "GAIN", "year", "20", "daily", "1");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 30);
        }

    }
}
