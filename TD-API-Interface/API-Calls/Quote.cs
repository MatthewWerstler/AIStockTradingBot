using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TD_API_Interface.API_Calls
{
    /// <summary>
    /// Current Quotes https://developer.tdameritrade.com/quotes/apis
    /// </summary>
    public static class Quote
    {
        /// <summary>
        /// Get current quotes for one your more market symbol.
        /// Based on https://developer.tdameritrade.com/quotes/apis/get/marketdata/quotes
        /// </summary>
        /// <param name="client">httpClient with OAuth Header</param>
        /// <param name="apiKey">Pass your OAuth User ID to make an unauthenticated request for delayed data.</param>
        /// <param name="symbols">List of one or more symbols to lookup.</param>
        /// <returns>Returns HttpResponseMessage which contents contain a list of QuoteETF, QuoteForex, QuoteFuture, QuoteFutureOption, 
        /// QuoteIndex, QuoteMutualFund, and/or QuoteOption data objects. Logic will be required to determine which object to populate.</returns>
        public static HttpResponseMessage getQuotes(HttpClient client, string apiKey, List<string> symbols)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/marketdata/quotes?";
            apiURL += $"{(!string.IsNullOrWhiteSpace(apiKey) ? $"apiKey={apiKey}&" : "")}";
            
            string symbol = string.Join(",", symbols);
            apiURL += $"symbol={symbol}";

            return client.GetAsync(apiURL).Result;
        }
    }
}
