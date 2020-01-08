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
    public class TestAccountsAndTrading
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
        public void ShouldBeAbleToPullOrderAndOrPositionsOnAllLinkedAccounts()
        {
            var results = TD_API_Interface.API_Calls.AccountsAndTrading.getAccounts(testingHttpClient.client, "positions,orders");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getAccounts(testingHttpClient.client, "positions");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getAccounts(testingHttpClient.client, "orders");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
        }

        [TestMethod]
        public void ShouldBeAbleToPullOrderAndOrPositionsOnAllLinkedAccount()
        {
            var results = TD_API_Interface.API_Calls.AccountsAndTrading.getAccount(testingHttpClient.client, testingHttpClient.account01, "positions,orders");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getAccount(testingHttpClient.client, testingHttpClient.account01, "positions");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getAccount(testingHttpClient.client, testingHttpClient.account01, "orders");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
        }
    }
}
