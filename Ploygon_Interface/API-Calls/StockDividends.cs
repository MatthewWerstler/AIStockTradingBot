using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ploygon.API_Calls
{
    public static class StockDividends
    {
        public static HttpResponseMessage getStockDividendDates(HttpClient client, string APIKey, string StockTicker)
        {
            string apiURL = $"https://api.polygon.io/v2/reference/dividends/{StockTicker}?apiKey={APIKey}";
            return client.GetAsync(apiURL).Result;
        }
        public static HttpResponseMessage getStockDividendDatesVersion3(HttpClient client, string APIKey, string StockTicker)
        {
            string apiURL = $"https://api.polygon.io/v3/reference/dividends?ticker={StockTicker}&apiKey={APIKey}";
            return client.GetAsync(apiURL).Result;
        }
    }
}
