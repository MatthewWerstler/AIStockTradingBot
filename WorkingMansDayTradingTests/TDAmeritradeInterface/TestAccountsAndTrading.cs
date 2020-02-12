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
using TD_API_Interface.PostModels;

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
        public void ShouldBeAbleToCancelAnOrder()
        {
            order testOrder = new order(true, "MSFT", 1, 10);  //If my account executes a spare of Microsoft of a dollar it will be my lucky day
            var results = TD_API_Interface.API_Calls.AccountsAndTrading.postCreateOrder(testingHttpClient.client, testingHttpClient.account01, testOrder);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.Created);

            results = TD_API_Interface.API_Calls.AccountsAndTrading.getOrders(testingHttpClient.client, testingHttpClient.account01, DateTime.Now.AddSeconds(-10), DateTime.Now);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            dynamic ordersContent = JsonConvert.DeserializeObject(contents);
            string orderID = ((IEnumerable)ordersContent).Cast<dynamic>().Where(q => q.quantity == 1.0 && q.price == 10.0).Select(s=>s.orderId).First();

            results = TD_API_Interface.API_Calls.AccountsAndTrading.CancelOrder(testingHttpClient.client, testingHttpClient.account01, orderID);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);

        }


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


        [TestMethod]
        public void ShouldBeAbleToCreateARealOrder()
        {
            order testOrder = new order(true, "MSFT", 1, 10);  //If my account executes a spare of Microsoft of a dollar it will be my lucky day
            var results = TD_API_Interface.API_Calls.AccountsAndTrading.postCreateOrder(testingHttpClient.client, testingHttpClient.account01, testOrder);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.Created);
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

        [TestMethod]
        public void ShouldBeAbleToCreateASavedOrder()
        {
            order testOrder = new order(true, "MSFT", 1, 1);
            var results = TD_API_Interface.API_Calls.AccountsAndTrading.postCreateSavedOrder(testingHttpClient.client, testingHttpClient.account01, testOrder);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
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

        #region "order object model"

        [TestMethod]
        public void ShouldBeAbleToCreateAnOrderObjectForSimpleLimitStockPurchaseOrSale()
        {
            //Sample buy order from https://developer.tdameritrade.com/content/place-order-samples Test to match
            //{
            //    "orderType": "MARKET",  //I however generally don't do market orders 
            //  "session": "NORMAL",
            //  "duration": "DAY",
            //  "orderStrategyType": "SINGLE",  ****
            //  "orderLegCollection": [
            //    {
            //      "instruction": "Buy",
            //      "quantity": 15,
            //      "instrument": {
            //        "symbol": "XYZ",
            //        "assetType": "EQUITY"
            //        }
            //     }]
            //}
            TD_API_Interface.PostModels.order testOrder = new TD_API_Interface.PostModels.order(true, "MSFT", 1, 1);
            Assert.IsTrue(testOrder.accountId.ToString() == testingHttpClient.account01);
            Assert.IsTrue(testOrder.orderStrategyType == "SINGLE");
            Assert.IsTrue(testOrder.orderLegCollection[0].instruction == "BUY");
            Assert.IsTrue(testOrder.orderLegCollection[0].quantity == 1);
            Assert.IsTrue(testOrder.orderLegCollection[0].instrument.symbol == "MSFT");
            Assert.IsTrue(testOrder.orderLegCollection[0].instrument.assetType == "EQUITY");

            string dOrder = JsonConvert.SerializeObject(testOrder,
                            Newtonsoft.Json.Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
            Assert.IsTrue(testOrder.orderLegCollection[0].instruction == "BUY");
            Assert.IsNotNull(dOrder);

            //Simple Sell order test
            TD_API_Interface.PostModels.order testSellOrder = new TD_API_Interface.PostModels.order(false, "MSFT", 1, 10000);
            Assert.IsTrue(testSellOrder.orderStrategyType == "SINGLE");
            Assert.IsTrue(testSellOrder.orderLegCollection[0].instruction == "SELL");
            Assert.IsTrue(testSellOrder.orderLegCollection[0].quantity == 1);
            Assert.IsTrue(testSellOrder.orderLegCollection[0].instrument.symbol == "MSFT");
            Assert.IsTrue(testSellOrder.orderLegCollection[0].instrument.assetType == "EQUITY");

        }


        #endregion
    }
}
