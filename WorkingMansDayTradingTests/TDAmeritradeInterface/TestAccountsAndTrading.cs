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

        #region order test(s)
        [TestMethod]
        public void ShouldBeAbleToGetOrder()
        {
            var results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrders(testingHttpClient.client, testingHttpClient.account01);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrders(testingHttpClient.client, testingHttpClient.account01, "FILLED");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrders(testingHttpClient.client, testingHttpClient.account01, 2);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrders(testingHttpClient.client, testingHttpClient.account01, "FILLED", 2);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrders(testingHttpClient.client, testingHttpClient.account01, DateTime.Now.AddDays(-60), DateTime.Now);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrders(testingHttpClient.client, testingHttpClient.account01, DateTime.Now.AddDays(-60), DateTime.Now, "FILLED");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
        }

        [TestMethod]
        public void ShouldBeAbleToGetOrdersForAllLinkedAccounts()
        {
            var results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrdersAllAccounts(testingHttpClient.client);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrdersAllAccounts(testingHttpClient.client, "FILLED");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrdersAllAccounts(testingHttpClient.client, 2);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrdersAllAccounts(testingHttpClient.client, "FILLED", 2);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrdersAllAccounts(testingHttpClient.client, DateTime.Now.AddDays(-60), DateTime.Now);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrdersAllAccounts(testingHttpClient.client, DateTime.Now.AddDays(-60), DateTime.Now, "FILLED");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
        }

        #endregion

        //sadly I do not understand the difference between and order and saved order - but that is why I write test while mapping a API
        #region saved order test(s)
        [TestMethod]
        public void ShouldBeAbleToGetSavedOrders()
        {
            var results = TD_API_Interface.API_Calls.AccountsAndTrading.getSavedOrders(testingHttpClient.client, testingHttpClient.account01);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            dynamic data = JsonConvert.DeserializeObject(contents);
            string savedOrderId = ((IEnumerable)data).Cast<dynamic>().Select(s => s.savedOrderId).First();
            Assert.IsNotNull(savedOrderId);
            results = TD_API_Interface.API_Calls.AccountsAndTrading.getSavedOrder(testingHttpClient.client, testingHttpClient.account01, savedOrderId);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
        }

        #endregion

        #region Accounts Test
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

        #endregion 
    }
}
