using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace TD_API_Interface.API_Calls
{
    /// <summary>
    /// APIs to access transaction history on the account https://developer.tdameritrade.com/transaction-history/apis
    /// </summary>
    public static class TransactionHistory
    {
        /// <summary>
        /// Transaction for a specific account.
        /// </summary>
        /// <param name="client">httpClient with OAuth Header</param>
        /// <param name="accountId">TD Ameritrade Account Number</param>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>HttpResponseMessage</returns>
        public static HttpResponseMessage getTransaction(HttpClient client, string accountId, string transactionId)
        {   ///--> I have not been able to successfully test this on because I have not made a trade in a while (with the account I am using)
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/transactions/{transactionId}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Transactions for a specific account. (For at date range)  https://developer.tdameritrade.com/transaction-history/apis/get/accounts/%7BaccountId%7D/transactions-0
        /// </summary>
        /// <param name="client">httpClient with OAuth Header</param>
        /// <param name="accountId">TD Ameritrade Account Number</param>
        /// <param name="type">Only transactions with the specified type will be returned.</param>
        /// <param name="symbol">Only transactions with the specified symbol will be returned.</param>
        /// <param name="startDate">Only transactions after the Start Date will be returned.
        ///         Note: The maximum date range is one year.Valid ISO-8601 formats are :
        ///         yyyy-MM-dd.</param>
        /// <param name="endDate">Only transactions before the End Date will be returned.
        ///         Note: The maximum date range is one year.Valid ISO-8601 formats are :
        ///         yyyy-MM-dd.</param>
        /// <returns>API HttpResponseMessage</returns>
        public static HttpResponseMessage getTransactions(HttpClient client, string accountId, string type = "All", string symbol = "", string endDate = "", string startDate = "")
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/transactions?";
            apiURL += $"{ (!string.IsNullOrWhiteSpace(type) ? $"type={type}&" : "")}";
            apiURL += $"{ (!string.IsNullOrWhiteSpace(symbol) ? $"symbol={symbol}&" : "")}";
            apiURL += $"{ (!string.IsNullOrWhiteSpace(startDate) ? $"startDate={startDate}&" : "")}";
            apiURL += $"{ (!string.IsNullOrWhiteSpace(endDate) ? $"endDate={endDate}&" : "")}";
            return client.GetAsync(apiURL).Result;
        }
    }
}
