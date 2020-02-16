using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD_API_Interface;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WorkingMansDayTradingTests
{
    [TestClass]
    public class TestInstruments
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
        public void ShouldBeAbleToRetieveInstrumentSearchResults()
        {
            var results = TD_API_Interface.API_Calls.Instruments.getSearchInstrument(testingHttpClient.client, testingHttpClient.apiKey, "EFC", "symbol-search");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;

            results = TD_API_Interface.API_Calls.Instruments.getSearchInstrument(testingHttpClient.client, testingHttpClient.apiKey, "AA.*", "symbol-regex");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
            //desc-search
            results = TD_API_Interface.API_Calls.Instruments.getSearchInstrument(testingHttpClient.client, testingHttpClient.apiKey, "Microsoft", "desc-search");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);

            //desc-regex
            results = TD_API_Interface.API_Calls.Instruments.getSearchInstrument(testingHttpClient.client, testingHttpClient.apiKey, "Micro.[B-V].*", "desc-regex");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);

            //fundamental
            results = TD_API_Interface.API_Calls.Instruments.getSearchInstrument(testingHttpClient.client, testingHttpClient.apiKey, "EFC", "fundamental");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
        }

        [TestMethod]
        public void ShouldBeAbleGetInstrument()
        {
            var results = TD_API_Interface.API_Calls.Instruments.getIntrument(testingHttpClient.client, testingHttpClient.apiKey, "MSFT");
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(contents);
        }
    }
}
