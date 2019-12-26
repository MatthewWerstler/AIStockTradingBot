using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace TD_API_Interface.API_Calls
{
    /// <summary>
    /// Historical price data for charts https://developer.tdameritrade.com/price-history/apis
    /// </summary>
    public static class PriceHistory
    {
        /// <summary>
        /// Get price history for a symbol
        /// </summary>
        /// <param name="client">httpClient with OAuth Header</param>
        /// <param name="apiKey">Pass your OAuth User ID to make an unauthenticated request for delayed data.</param>
        /// <param name="symbol">stock symbol CASE SENSTIVE</param>
        /// <param name="periodType">The type of period to show. Valid values are day, month, year, or ytd (year to date). Default is day.</param>
        /// <param name="period">The number of periods to show.
        ///   Example: For a 2 day / 1 min chart, the values would be:
        ///   period: 2
        ///   periodType: day
        ///   frequency: 1
        ///   frequencyType: min
        ///   Valid periods by periodType(defaults marked with an asterisk) :
        ///   day: 1, 2, 3, 4, 5, 10*
        ///   month: 1*, 2, 3, 6
        ///   year: 1*, 2, 3, 5, 10, 15, 20
        ///   ytd: 1*</param>
        /// <param name="frequencyType">The type of frequency with which a new candle is formed.
        ///         Valid frequencyTypes by periodType(defaults marked with an asterisk):
        ///         day: minute*
        ///         month: daily, weekly*
        ///         year: daily, weekly, monthly*
        ///         ytd: daily, weekly*</param>
        /// <param name="frequency">The number of the frequencyType to be included in each candle.
        ///         Valid frequencies by frequencyType(defaults marked with an asterisk):
        ///         minute: 1*, 5, 10, 15, 30
        ///         daily: 1*
        ///         weekly: 1*
        ///         monthly: 1*</param>
        /// <param name="endDate">End date as milliseconds since epoch. If startDate and endDate are provided, 
        ///     period should not be provided. Default is previous trading day.</param>
        /// <param name="startDate">Start date as milliseconds since epoch. If startDate and endDate are provided, 
        ///     period should not be provided.</param>
        /// <param name="needExtendedHoursData">true to return extended hours data, false for regular market hours only. Default is true</param>
        /// <returns></returns>
        public static HttpResponseMessage getPriceHistory(HttpClient client, string apiKey, string symbol, string periodType = "", string period = "", string frequencyType = "", string frequency = "", string endDate = "", string startDate = "", bool needExtendedHoursData = true)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/marketdata/{symbol}/pricehistory?";
            apiURL += $"{ (!string.IsNullOrWhiteSpace(apiKey) ? $"apiKey={apiKey}&" : "")}";
            apiURL += $"{(!string.IsNullOrWhiteSpace(periodType) ? $"periodType={periodType}&" : "")}";
            apiURL += $"{(!string.IsNullOrWhiteSpace(period) ? $"period={period}" : "")}&";
            apiURL += $"{(!string.IsNullOrWhiteSpace(frequencyType) ? $"frequencyType={frequencyType}&" : "")}";
            apiURL += $"{(!string.IsNullOrWhiteSpace(frequency) ? $"frequency={frequency}&" : "")}";
            apiURL += $"{(!string.IsNullOrWhiteSpace(endDate) ? $"endDate={endDate}&" : "")}";
            apiURL += $"{(!string.IsNullOrWhiteSpace(startDate) ? $"startDate={startDate}&" : "")}";
            apiURL += $"needExtendedHoursData={needExtendedHoursData.ToString().ToLower()}";
           
            return client.GetAsync(apiURL).Result;
        }
    }
}
