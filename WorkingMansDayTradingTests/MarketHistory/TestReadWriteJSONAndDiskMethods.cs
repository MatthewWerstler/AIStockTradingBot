using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using MarketHistory;
using System.Linq;
using System.Text.RegularExpressions;

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

        [TestMethod]
        public void ShouldBeAbleToBuildListOfQuotesFromJsonFile()
        {
            string sampleJSONQuoteFilePath = "..\\..\\..\\Samples\\EFC-ByMinute-201912090230-201912200906.json";
            List<DataModels.Quote> EFCbyMinute = ReadWriteJSONToDisk.getQuotesFromJSON(sampleJSONQuoteFilePath);
            Assert.IsTrue(EFCbyMinute.Count > 3);
        }

        [TestMethod]
        public void MapCombiningPriceLists()
        {
            string sampleJSONQuoteFilePath1 = "..\\..\\..\\Samples\\EFC-ByMinute-201912090230-201912200906.json";
            string sampleJSONQuoteFilePath2 = "..\\..\\..\\Samples\\EFC-ByMinute-201912110230-201912240607.json";
            List<DataModels.Quote> EFCbyMinute1 = ReadWriteJSONToDisk.getQuotesFromJSON(sampleJSONQuoteFilePath1);
            List<DataModels.Quote> EFCbyMinute2 = ReadWriteJSONToDisk.getQuotesFromJSON(sampleJSONQuoteFilePath2);
            List<DataModels.Quote> EFCbyMinuteFinal = EFCbyMinute1.Union(EFCbyMinute2, new DataModels.CompareQuoteByDatetime())
                                                                  .OrderBy(o => o.datetime)
                                                                  .ToList();
            Assert.IsTrue(EFCbyMinuteFinal.Count > EFCbyMinute1.Count && EFCbyMinuteFinal.Count > EFCbyMinute2.Count);
            Assert.IsTrue(EFCbyMinuteFinal.Contains(EFCbyMinute1.First()) && EFCbyMinuteFinal.Contains(EFCbyMinute1.Last()));
            //foreach (DataModels.Quote thisQuote in EFCbyMinute2)
            //    Assert.IsTrue(EFCbyMinuteFinal.Contains(thisQuote));
            List<DataModels.Quote> StockHistoryCombinedList = StockHistory.CombineQuoteLists(EFCbyMinute1, EFCbyMinute2);
            Assert.IsTrue(StockHistoryCombinedList.Count == EFCbyMinuteFinal.Count);
        }

        [TestMethod]
        public void ShouldBeAbleToGetAListOfByMinuteFiles()
        {
            string samplePath = "..\\..\\..\\Samples";
            string[] files = Directory.GetFiles(samplePath);
            List<DataModels.QuoteFile> quoteFiles = new List<DataModels.QuoteFile>();
            foreach (string file in files)
            {
                if(file.EndsWith(".json"))
                { 
                    DataModels.QuoteFile thisFile = new DataModels.QuoteFile();
                    thisFile.path = file;
                    thisFile.info = new FileInfo(file);
                    List<string> splitname = thisFile.info.Name.Replace(".json", "").Split('-').ToList();
                    Regex rgx = new Regex(@"\d");
                    Assert.IsTrue(rgx.IsMatch(splitname[3]));
                    thisFile.startDate = splitname.Where(q => rgx.IsMatch(q.ToString())).First();
                    thisFile.endDate = splitname.Where(q => rgx.IsMatch(q)).Last();
                    quoteFiles.Add(thisFile);
                }
            }
            Assert.IsTrue(quoteFiles.Count > 1);
            Assert.IsNotNull(quoteFiles.First().info.Name);
            List<DataModels.QuoteFile> quoteFilesFromFunction = ReadWriteJSONToDisk.getQuotesFileListFromDirectory(samplePath);
            Assert.IsTrue(quoteFiles.Count == quoteFilesFromFunction.Count);
        }
    }
}
