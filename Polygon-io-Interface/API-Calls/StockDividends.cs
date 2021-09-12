using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Polygon_io_Interface.API_Calls
{
    public static class StockDividends
    {
        public static HttpResponseMessage getStockDividendDates(HttpClient client, string StockTicker)
        {
            string apiURL = $"https://api.polygon.io/v2/reference/dividends/#StockTicker#";
            return client.GetAsync(apiURL).Result;
        }
    }
}
