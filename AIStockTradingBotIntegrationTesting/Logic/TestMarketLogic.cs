using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AIStockTradingBotLogic;
using DataModels;
using Newtonsoft.Json.Linq;
using DataModels;

namespace WorkingMansDayTradingTests.Logic
{
    [TestClass]
    public class TestMarketLogic
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
        public void ShouldBeAbleToReturnMarketHoursAsAnObject()
        {
            Sessionhours hours = Market.getEquityMarketHours(testingHttpClient.client, DateTime.Now);
            Assert.IsNotNull(hours.postMarket);           
        }
    }
}
