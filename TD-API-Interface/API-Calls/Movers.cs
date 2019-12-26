using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace TD_API_Interface.API_Calls
{
    /// <summary>
    /// Retrieve mover information by index symbol, direction type and change https://developer.tdameritrade.com/movers/apis
    /// </summary>
    public static class Movers
    {
        /// <summary>
        /// Top 10 (up or down) movers by value or percent for a particular market
        /// </summary>
        /// <param name="client">HttpClient with OAuth header</param>
        /// <param name="index">The index symbol to get movers from. Can be $COMPX, $DJI, or $SPX.X. Click to edit the value.
        /// <param name="direction">"up" or "down" - To return movers with the specified directions of up or down</param>
        /// <param name="change">"percent" or "value" To return movers with the specified change types of percent or value</param>
        /// <param name="apiKey">Pass your OAuth User ID to make an unauthenticated request for delayed data.  (So...  Maybe you get real time info with a key)  The only reason it matters is because non commerical ket as a max call rate</param>
        /// <returns>HttpResponseMessage from api</returns>
        public static HttpResponseMessage getMovers(HttpClient client, string index, string direction, string change, string apiKey = "")
        {
            string apiURL = $"https://api.tdameritrade.com/v1/marketdata/{index}/movers?direction={direction}&change={change}";
            if (!string.IsNullOrWhiteSpace(apiKey))
                apiURL = $"{apiURL}&apikey={apiKey}";
            return client.GetAsync(apiURL).Result;
        }
    }
}
