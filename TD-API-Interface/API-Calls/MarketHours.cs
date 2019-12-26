using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Globalization;

namespace TD_API_Interface.API_Calls
{
    /// <summary>
    /// Operation Hours for markets https://developer.tdameritrade.com/market-hours/apis
    /// </summary>
    public static class MarketHours
    {

        /// <summary>
        ///Get Hours for Multiple Markets
        ///https://api.tdameritrade.com/v1/marketdata/hours
        ///Retrieve market hours for specified markets
        /// </summary>
        /// <param name="client">HttpClient with Auth Head already attached</param>
        /// <param name="apiKey">(Optional) Pass your Client ID if making an unauthenticated request</param>
        /// <param name="markets">The markets for which you're requesting market hours, comma-separated. Valid markets are EQUITY, OPTION, FUTURE, BOND, or FOREX.</param>
        /// <param name="date">"The date for which market hours information is requested. Valid ISO-8601 formats are : yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz."</param>
        /// <returns>API HttpResponseMessage</returns>
        public static HttpResponseMessage getHoursForMultipleMarkets(HttpClient client, string markets, DateTime date, string apiKey = "")
        {
            string strFormattedDate = date.ToString("yyyy-MM-dd");
            string apiURL = $"https://api.tdameritrade.com/v1/marketdata/hours?markets={markets}&date={strFormattedDate}";
            return client.GetAsync(apiURL).Result;
        }


        /// <summary>
        /// Get Hours for a Single Market
        /// https://api.tdameritrade.com/v1/marketdata/{market}/hours
        /// Retrieve market hours for specified single market
        /// </summary>
        /// <param name="client">HttpClient with Auth Head already attached</param>
        /// <param name="apiKey">Pass your OAuth User ID to make an unauthenticated request for delayed data.</param>
        /// <param name="market">market hours for specified single market</param>
        /// <param name="date">"The date for which market hours information is requested. Valid ISO-8601 formats are : yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz."</param>
        /// <returns>API HttpResponseMessage</returns>
        public static HttpResponseMessage getHoursForMarket(HttpClient client, string market, DateTime date, string apiKey = "")
        {
            string strFormattedDate = date.ToString("yyyy-MM-dd");
            string apiURL = $"https://api.tdameritrade.com/v1/marketdata/{market}/hours?date={strFormattedDate}";
            return client.GetAsync(apiURL).Result;
        }
    }
}
