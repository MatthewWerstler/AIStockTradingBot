using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using MarketHistory;

namespace WorkingMansDayTradingTests.MarketHistory
{
    [TestClass]
    public class TestReadWriteJSONAndDiskMethods
    {

        /// <summary>
        /// Yep, I would totally come up with a shorten config setup.
        /// </summary>
        WorkingMansDayTradingTests.TDAmeritradeInterface.HttpClientHelper testingHttpClient;

        [TestInitialize]
        public void Setup()
        {
            testingHttpClient = new WorkingMansDayTradingTests.TDAmeritradeInterface.HttpClientHelper();
        }
        [TestCleanup]
        public void Dispose()
        {
            testingHttpClient.Dispose();
        }

        [TestMethod]
        public void testCreateDirectoryMethod()
        {
            Assert.IsTrue(Directory.Exists(testingHttpClient.path));
            ReadWriteJSONToDisk.testCreateDirectory($"{testingHttpClient.path}//Price_History");
            Assert.IsTrue(Directory.Exists($"{testingHttpClient.path}//Price_History"));
            ReadWriteJSONToDisk.testCreateDirectory($"{testingHttpClient.path}//Price_History//TEST//ByMinute");
            Assert.IsTrue(Directory.Exists($"{testingHttpClient.path}//Price_History//TEST//ByMinute"));
        }
    }
}
