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
            DateTime dt = DateTime.Now;//in market
            Sessionhours hours = Market.getEquityMarketHours(testingHttpClient.client, dt);
            Assert.IsNotNull(hours.postMarket);
        }

        [TestMethod]
        public void ShouldBeAbleToFigureOutTheCurrentSession()
        {
            Sessionhours hours = Market.getEquityMarketHours(testingHttpClient.client, DateTime.Now);
            string currentSession = Market.currentSession(hours, DateTime.Now);
            List<string> sessions = new List<string> { "preMarket", "regularMarket", "postMarket", "outsideMarket", "resetSession","nonMarketDay"};
            Assert.IsTrue(sessions.Contains(currentSession));
            //DateTime dt = DateTime.Parse("1/22/2020 10:00");//in market <--- api does not cover past dates
            //hours = Market.getEquityMarketHours(testingHttpClient.client, dt);
            //currentSession = Market.currentSession(hours, dt);
            //Assert.IsTrue(currentSession == "regularMarket");
        }
    }
}
