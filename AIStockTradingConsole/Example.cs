using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Avapi.AvapiTIME_SERIES_DAILY;
using Avapi;

namespace AIStockTradingConsole
{
    public class Example
    {
        public static void Test(string Api_Key)
        { 
            AvapiConnection connection = AvapiConnection.Instance;

            // Set up the connection and pass the API_KEY provided by alphavantage.co
            connection.Connect(Api_Key);

            // Get the TIME_SERIES_DAILY query object
            Int_TIME_SERIES_DAILY time_series_daily =
                connection.GetQueryObject_TIME_SERIES_DAILY();

            // Perform the TIME_SERIES_DAILY request and get the result
            IAvapiResponse_TIME_SERIES_DAILY time_series_dailyResponse =
            time_series_daily.Query(
                 "MSFT",
                 Const_TIME_SERIES_DAILY.TIME_SERIES_DAILY_outputsize.compact);

            // Printout the results
            Console.WriteLine("******** RAW DATA TIME_SERIES_DAILY ********");
            Console.WriteLine(time_series_dailyResponse.RawData);

            Console.WriteLine("******** STRUCTURED DATA TIME_SERIES_DAILY ********");
            var data = time_series_dailyResponse.Data;
            if (data.Error)
            {
                Console.WriteLine(data.ErrorMessage);
            }
            else
            {
                Console.WriteLine("Information: " + data.MetaData.Information);
                Console.WriteLine("Symbol: " + data.MetaData.Symbol);
                Console.WriteLine("LastRefreshed: " + data.MetaData.LastRefreshed);
                Console.WriteLine("OutputSize: " + data.MetaData.OutputSize);
                Console.WriteLine("TimeZone: " + data.MetaData.TimeZone);
                Console.WriteLine("========================");
                Console.WriteLine("========================");
                foreach (var timeseries in data.TimeSeries)
                {
                    Console.WriteLine("open: " + timeseries.open);
                    Console.WriteLine("high: " + timeseries.high);
                    Console.WriteLine("low: " + timeseries.low);
                    Console.WriteLine("close: " + timeseries.close);
                    Console.WriteLine("volume: " + timeseries.volume);
                    Console.WriteLine("DateTime: " + timeseries.DateTime);
                    Console.WriteLine("========================");
                }
            }
        }
    }
}
