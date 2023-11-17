using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Ploygon_Interface.API_Calls
{
    public class StockAggregates
    {

        public static HttpResponseMessage getStockMinuteData(HttpClient client, string APIKey, string StockTicker)
        {
            string apiURL = $"https://api.polygon.io/v2/aggs/ticker/{StockTicker}/range/1/minute/2023-10-09/2023-11-09?adjusted=false&sort=asc&limit=50000&apiKey={APIKey}";
            return client.GetAsync(apiURL).Result;
        }
        
    }
}
