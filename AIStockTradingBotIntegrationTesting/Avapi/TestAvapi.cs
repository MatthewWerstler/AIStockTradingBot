using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AvapiTest;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using Avapi.AvapiTIME_SERIES_INTRADAY;

namespace WorkingMansDayTradingTests.Avapi
{
    [TestClass]
    public class TestAvapi
    {

        private string alpha_vantage_key
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .AddUserSecrets<UnitTestSecretsAndHttpClient>();
                IConfiguration Configuration = builder.Build();
                return Configuration["alpha_vantage_key"];
            }
        }

        [TestMethod]
        public void ShouldBeAbleToReturnSomethingFromAvapi()
        {
            IAvapiResponse_TIME_SERIES_INTRADAY efcIntradayData = Example.TestTimeByMinutes(alpha_vantage_key);
            Assert.IsNotNull(efcIntradayData);
            
            var data = Example.Test(alpha_vantage_key);
            //Console.WriteLine("Information: " + data.MetaData.Information);
            //Console.WriteLine("Symbol: " + data.MetaData.Symbol);
            //Console.WriteLine("LastRefreshed: " + data.MetaData.LastRefreshed);
            //Console.WriteLine("OutputSize: " + data.MetaData.OutputSize);
            //Console.WriteLine("TimeZone: " + data.MetaData.TimeZone);
            //Console.WriteLine("========================");
            //Console.WriteLine("========================");
            //foreach (var timeseries in data.TimeSeries)
            //{
            //    Console.WriteLine("open: " + timeseries.open);
            //    Console.WriteLine("high: " + timeseries.high);
            //    Console.WriteLine("low: " + timeseries.low);
            //    Console.WriteLine("close: " + timeseries.close);
            //    Console.WriteLine("volume: " + timeseries.volume);
            //    Console.WriteLine("DateTime: " + timeseries.DateTime);
            //    Console.WriteLine("========================");
            //}
            Assert.IsNotNull(data.MetaData.Information);
        }
    }
        
}
