using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Avapi.AvapiTIME_SERIES_DAILY;
using Avapi.AvapiTIME_SERIES_INTRADAY;
using Avapi;

namespace AvapiTest
{
    public class Example
    {
        public static IAvapiResponse_TIME_SERIES_DAILY_Content Test(string Api_Key)
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
            //Console.WriteLine("******** RAW DATA TIME_SERIES_DAILY ********");
            //Console.WriteLine(time_series_dailyResponse.RawData);

            //Console.WriteLine("******** STRUCTURED DATA TIME_SERIES_DAILY ********");
            var data = time_series_dailyResponse.Data;
            if (data.Error)
            {
                //Console.WriteLine(data.ErrorMessage);
                throw new Exception(data.ErrorMessage);
            }
            return data;
        }

        public static IAvapiResponse_TIME_SERIES_INTRADAY TestTimeByMinutes(string Api_Key)
        {
            AvapiConnection connection = AvapiConnection.Instance;

            // Set up the connection and pass the API_KEY provided by alphavantage.co
            connection.Connect(Api_Key);

            // Get the  query object
            Int_TIME_SERIES_INTRADAY intraday_series =
                connection.GetQueryObject_TIME_SERIES_INTRADAY();


            // Get the TIME_SERIES_DAILY query object
            //Int_TIME_SERIES_DAILY time_series_daily =
            //    connection.GetQueryObject_TIME_SERIES_DAILY();

            // Perform the  request and get the result
            IAvapiResponse_TIME_SERIES_INTRADAY time_series_IntradayResponse =
                intraday_series.Query("EFC", Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_interval.n_1min, Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_outputsize.full);

            return time_series_IntradayResponse;


        }
    }
}
