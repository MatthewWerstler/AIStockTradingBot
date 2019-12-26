using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD_API_Interface;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WorkingMansDayTradingTests.TDAmeritradeInterface
{
    [TestClass]
    public class TestMarketHoursAPICalls
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

        [TestMethod]
        public void ShouldBeAbleToRetrieveMarketHours()
        {
            var results = TD_API_Interface.API_Calls.MarketHours.getHoursForMarket(testingHttpClient.client, "BOND", DateTime.Now);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);

            results = TD_API_Interface.API_Calls.MarketHours.getHoursForMultipleMarkets(testingHttpClient.client, "BOND,FOREX", DateTime.Now);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);

        }
    }
}
