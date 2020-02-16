using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD_API_Interface;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Collections;
using Newtonsoft.Json;
using DataModels;
using AIStockTradingBotLogic;

namespace WorkingMansDayTradingTests.Logic
{
    [TestClass]
    public class TestAccountHydrationLogic
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
        public void ShouldBeAbleToGetAccountWatchLists()
        {
            Account testAccount = new Account(testingHttpClient.account01);
            AccountHydrate.getWishLists(testingHttpClient.client, testAccount);
            Assert.IsTrue(testAccount.WatchLists.Count > 0);
        }
    }
}
