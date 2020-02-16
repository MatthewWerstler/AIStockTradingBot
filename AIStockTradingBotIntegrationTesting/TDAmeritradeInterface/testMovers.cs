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
    public class testMovers
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
        public void ShouldBeAbleToGetTodaysMarketsMoversFromAPI()
        {
            //S&P 500, 
            var results = TD_API_Interface.API_Calls.Movers.getMovers(testingHttpClient.client, "$COMPX", "up", "value", testingHttpClient.apiKey);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            var contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);
            //Dow Jones Industrial Average
            results = TD_API_Interface.API_Calls.Movers.getMovers(testingHttpClient.client, "$DJI", "up", "value", testingHttpClient.apiKey);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);
            //Nasdaq Composite
            results = TD_API_Interface.API_Calls.Movers.getMovers(testingHttpClient.client, "$SPX.X", "up", "value", testingHttpClient.apiKey);
            Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            contents = results.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(contents.Length > 2);
            ///     Symbol         Market Index   
            ///     DJIA        Dow Jones Industrial Average    	
            ///     DJT         Dow Jones Transportation Average   
            ///     DJU         Dow Jones Utility Average Index 	
            ///     NDX         NASDAQ 100 Index(NASDAQ Calculation)   
            ///     COMP        NASDAQ Composite Index  
            ///     NYA         NYSE Composite Index 
            ///     SPX         S&P 500 Index 	
            ///     MID         S&P 400 Mid Cap Index 	 
            ///     OEX         S&P 100 Index 
            ///     IXCO        NASDAQ Computer Index 	
            ///     SOX         PHLX Semiconductor Index 	
            ///     XAU         PHLX Gold/Silver Index 
            ///     XOI         NYSE Arca Oil Index
            ///     RUT         Russell 2000 Index 
            ///----> Other indexes do not seem to be covered---
            //results = TD_API_Interface.API_Calls.Movers.getMovers(testingHttpClient.client, "$DJU", "up", "value", testingHttpClient.apiKey);
            //Assert.IsTrue(results.StatusCode == System.Net.HttpStatusCode.OK);
            //contents = results.Content.ReadAsStringAsync().Result;
            //Assert.IsTrue(contents.Length > 2);
        }
    }
}
