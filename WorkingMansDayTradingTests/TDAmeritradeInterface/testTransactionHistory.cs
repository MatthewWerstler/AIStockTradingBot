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
    public class testTransactionHistory
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
        public void ShouldBeAbleToGetAllTransactionsForTimeFrameForAnAccountAndPullASingleTranscation()
        {
            var results = TD_API_Interface.API_Calls.TransactionHistory.getTransactions(testingHttpClient.client, testingHttpClient.account01);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);
            results = TD_API_Interface.API_Calls.TransactionHistory.getTransactions(testingHttpClient.client, testingHttpClient.account01, "All", "GAIN", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(-45).ToString("yyyy-MM-dd"));
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);
            //no symbol
            results = TD_API_Interface.API_Calls.TransactionHistory.getTransactions(testingHttpClient.client, testingHttpClient.account01, "All", "", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(-45).ToString("yyyy-MM-dd"));
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);
            string transID = getTransationID(contents);
            //if (!string.IsNullOrWhiteSpace(transID))
            //{
            //    //Access-Control-Max-Age: 3628800  --seems to be an issue with my last transaction (or this doees not work
            //    results = TD_API_Interface.API_Calls.TransactionHistory.getTransaction(testingHttpClient.client, testingHttpClient.account01, transID);
            //    Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            //    contents = results.Content.ReadAsStringAsync().Result;
            //    Assert.IsTrue(contents.Length > 2);
            //}
        }

        public string getTransationID(string contents)
        {
            dynamic data = JsonConvert.DeserializeObject(contents);
            return ((IEnumerable)data).Cast<dynamic>()
                .Where(p => p.type == "TRADE").Select(s => s.transactionId).FirstOrDefault();
            //            .OrderByDescending(o=>o.transactionDate).Select(s => s.transactionId).FirstOrDefault();
        }
    }
}
