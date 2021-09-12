using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;
using System.Collections;
using Ploygon.API_Calls;
using DataModels;

namespace WorkingMansDayTradingTests.PolygonioInterface
{
    [TestClass]
    public class testDividendHistory
    {
        WorkingMansDayTradingTests.PolygonioInterface.HttpClientHelper testingHttpClient;
        [TestInitialize]
        public void Setup()
        {
            testingHttpClient = new PolygonioInterface.HttpClientHelper();
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
        public void testGettingDividendHistory()
        {
            var results = StockDividends.getStockDividendDates(testingHttpClient.client, testingHttpClient.apiKey, "MSFT");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);
        }

    }
}
