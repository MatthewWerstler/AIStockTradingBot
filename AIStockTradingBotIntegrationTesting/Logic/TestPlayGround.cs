using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AIStockTradingBotLogic;
using DataModels;
using Newtonsoft.Json.Linq;
using System.Linq;
using DataModels;
using MarketHistory;
using System.Collections;

namespace WorkingMansDayTradingTests.Logic
{
    [TestClass]
    public class TestPlayGround
    {
        [TestMethod]
        public void ShouldBeAbleToReturnMarketHoursAsAnObject()
        {
            string sampleJSONQuoteFilePath = "..\\..\\..\\Samples\\EFC-ByMinute-201912090230-201912200906.json";
            List<DataModels.Quote> EFCbyMinute = ReadWriteJSONToDisk.getQuotesFromJSON(sampleJSONQuoteFilePath);
            long minEnochDate = ((IEnumerable)EFCbyMinute).Cast<dynamic>().Select(s => s.datetime).First();
            long maxEnochDate = ((IEnumerable)EFCbyMinute).Cast<dynamic>().Select(s => s.datetime).Last();
            //string strMinDate = UtilityMethods.EnochToyyyyMMddhhmmString(minEnochDate);
            //string strMaxDate = UtilityMethods.EnochToyyyyMMddhhmmString(maxEnochDate);
            DateTime dtmin = UtilityMethods.FromUnixTime(minEnochDate);
            DateTime dtmax = UtilityMethods.FromUnixTime(maxEnochDate);

            Assert.IsNotNull(EFCbyMinute);
        }
    }

    public class QuoteFileWithDT : DataModels.Quote 
    {
        public DateTime GetDateTime() => UtilityMethods.FromUnixTime(datetime);
    }
}
