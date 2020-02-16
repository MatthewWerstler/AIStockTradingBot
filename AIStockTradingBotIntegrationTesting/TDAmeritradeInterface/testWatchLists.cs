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

namespace WorkingMansDayTradingTests.TDAmeritradeInterface
{
    [TestClass]
    public class testWatchLists
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
        public void testGettingAllWatchListsForAccount()
        {
            //In order to make this work I created a watchlist on my account on the standard site
            var results = TD_API_Interface.API_Calls.WatchList.getWatchilistsforSingleAccount(testingHttpClient.client, testingHttpClient.account01);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);
            //var json = JsonConvert.DeserializeObject(contents);
            dynamic data = JsonConvert.DeserializeObject(contents);
            var wishLists = new DataModels.AllWatchLists(contents);
            Assert.IsFalse(string.IsNullOrWhiteSpace(wishLists.Lists.First().name));
            Assert.IsNotNull(wishLists.Lists.First().watchlistItems.First().symbol);
        }

        [TestMethod]
        public void shouldBeAbleToGetWatchListsForAllAttachedAccounts()
        {
            var results = TD_API_Interface.API_Calls.WatchList.getWishlistsForAllAccounts(testingHttpClient.client);
            var contents = results.Content.ReadAsStringAsync().Result;
            var wishLists = new DataModels.AllWatchLists(contents);
            Assert.IsTrue(wishLists.Lists.Count > 3);
        }

        [TestMethod]
        public void testGettingAnIndividualWatchListByID()
        {
            //In order to make this work I created a watchlist on my account on the standard site
            var results = TD_API_Interface.API_Calls.WatchList.getWatchilistsforSingleAccount(testingHttpClient.client, testingHttpClient.account01);
            var contents = results.Content.ReadAsStringAsync().Result;
            var watchListID = getTransationID(contents);
            results = TD_API_Interface.API_Calls.WatchList.getWatchilist(testingHttpClient.client, testingHttpClient.account01, watchListID);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 3);
        }


        public string getTransationID(string contents)
        {
            //tring watchListName = "TradeList";  //Sorry This is a Data sensitive test -- 
            dynamic data = JsonConvert.DeserializeObject(contents);
            return ((IEnumerable)data).Cast<dynamic>().Select(s => s.watchlistId).FirstOrDefault();
        }
    }


    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public string name { get; set; }
        public string watchlistId { get; set; }
        public string accountId { get; set; }
        public Watchlistitem[] watchlistItems { get; set; }
    }

    public class Watchlistitem
    {
        public int sequenceId { get; set; }
        public float quantity { get; set; }
        public float averagePrice { get; set; }
        public float commission { get; set; }
        public Instrument instrument { get; set; }
    }

    public class Instrument
    {
        public string symbol { get; set; }
        public string assetType { get; set; }
    }

}
