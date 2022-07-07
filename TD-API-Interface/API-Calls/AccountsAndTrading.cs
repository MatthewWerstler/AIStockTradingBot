using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using TD_API_Interface.PostModels;
using Newtonsoft.Json;

namespace TD_API_Interface.API_Calls
{
    /// <summary>
    ///https://developer.tdameritrade.com/account-access/apis
    ///APIs to access Account Balances, Positions, Trade Info and place 
    /// </summary>
    public static class AccountsAndTrading
    {
        #region Orders
        //Method
        //Description

        /// <summary>DELETE/Cancel Order = Cancel a specific order for a specific account.</summary>
        /// <param name="client">httpClient with OAuth</param>
        /// <param name="accountId">Account Number deleted order from</param>
        /// <param name="orderId">Order Id to be deleted</param>
        /// <returns>HttpResponesMessage from TDA API</returns>
        public static HttpResponseMessage CancelOrder(HttpClient client, string accountId, string orderId)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/orders/{orderId}";
            return client.DeleteAsync(apiURL).Result;
        }

        /// <summary>
        /// Get a single specific order by ID
        /// </summary>
        /// <param name="client">httpClient with OAuth</param>
        /// <param name="accountId">Account Number deleted order from</param>
        /// <param name="orderId">Order ID</param>
        /// <returns>HttpResponesMessage order response TDA API</returns>
        public static HttpResponseMessage getOrder(HttpClient client, string accountId, string orderId)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/orders/{orderId}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Orders By Path - Orders for a specific account.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="accountId">TD Ameritrade </param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrders(HttpClient client, string accountId)//, int maxResults, DateTime fromEnteredTime, DateTime toEnteredTime, string status)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/orders";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Orders By Path - Orders for a specific account.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="accountId">TD Ameritrade </param>
        /// <param name="maxResults">Sets a max number of results to be returned</param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrders(HttpClient client, string accountId, int maxResults)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/orders?maxResults={maxResults.ToString()}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Orders By Path - Orders for a specific account.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="accountId">TD Ameritrade </param>
        /// <param name="status">Specifies that only orders of this status should be returned.
        ///   acceptable values = "", AWAITING_PARENT_ORDER, AWAITING_CONDITION, AWAITING_MANUAL_REVIEW, ACCEPTED, AWAITING_UR_OUT, 
        ///     PENDING_ACTIVATION, QUEUED, WORKING, REJECTED, PENDING_CANCEL, CANCELED, PENDING_REPLACE, REPLACED, FILLED, EXPIRED
        /// </param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrders(HttpClient client, string accountId, string status)//, int maxResults, DateTime fromEnteredTime, DateTime toEnteredTime, string status)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/orders?status={status}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Orders By Path - Orders for a specific account.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="accountId">TD Ameritrade </param>
        /// <param name="status">Specifies that only orders of this status should be returned.
        ///   acceptable values = "", AWAITING_PARENT_ORDER, AWAITING_CONDITION, AWAITING_MANUAL_REVIEW, ACCEPTED, AWAITING_UR_OUT, 
        ///     PENDING_ACTIVATION, QUEUED, WORKING, REJECTED, PENDING_CANCEL, CANCELED, PENDING_REPLACE, REPLACED, FILLED, EXPIRED
        /// </param>
        /// <param name="maxResults">Sets a max number of results to be returned</param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrders(HttpClient client, string accountId, string status, int maxResults)//, DateTime fromEnteredTime, DateTime toEnteredTime, string status)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/orders?status={status}&maxResults={maxResults.ToString()}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Orders By Path - Orders for a specific account.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="accountId">TD Ameritrade </param>
        /// <param name="fromEnteredTime">Specifies that no orders entered before this time should be returned. Valid ISO-8601 formats are :
        ///  yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz Date must be within 60 days from today's date. 'toEnteredTime' must also be set.</param>
        /// <param name="toEnteredTime">Specifies that no orders entered after this time should be returned.Valid ISO-8601 formats are :
        ///  yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz. 'fromEnteredTime' must also be set.</param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrders(HttpClient client, string accountId, DateTime fromEnteredTime, DateTime toEnteredTime)//, int maxResults, DateTime fromEnteredTime, DateTime toEnteredTime)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/orders?fromEnteredTime={fromEnteredTime.ToString("yyyy-MM-dd")}&toEnteredTime={toEnteredTime.ToString("yyyy-MM-dd")}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Orders By Path - Orders for a specific account.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="accountId">TD Ameritrade </param>
        /// <param name="fromEnteredTime">Specifies that no orders entered before this time should be returned. Valid ISO-8601 formats are :
        ///  yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz Date must be within 60 days from today's date. 'toEnteredTime' must also be set.</param>
        /// <param name="toEnteredTime">Specifies that no orders entered after this time should be returned.Valid ISO-8601 formats are :
        ///  yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz. 'fromEnteredTime' must also be set.</param>
        /// <param name="status">Specifies that only orders of this status should be returned.
        ///   acceptable values = "", AWAITING_PARENT_ORDER, AWAITING_CONDITION, AWAITING_MANUAL_REVIEW, ACCEPTED, AWAITING_UR_OUT, 
        ///     PENDING_ACTIVATION, QUEUED, WORKING, REJECTED, PENDING_CANCEL, CANCELED, PENDING_REPLACE, REPLACED, FILLED, EXPIRED
        /// </param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrders(HttpClient client, string accountId, DateTime fromEnteredTime, DateTime toEnteredTime, string status)//, int maxResults, DateTime fromEnteredTime, DateTime toEnteredTime, string status)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/orders?status={status}&fromEnteredTime={fromEnteredTime.ToString("yyyy-MM-dd")}&toEnteredTime={toEnteredTime.ToString("yyyy-MM-dd")}";
            return client.GetAsync(apiURL).Result;
        }
               
        //GET
        //Get Orders By Query
        //https://api.tdameritrade.com/v1/orders
        //All orders for a specific account or, if account ID isn't specified, orders will be returned for all linked accounts

        /// <summary>
        /// Get Orders By Path - Orders for a all linked accounts.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrdersAllAccounts(HttpClient client)//, int maxResults, DateTime fromEnteredTime, DateTime toEnteredTime, string status)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/orders";
            return client.GetAsync(apiURL).Result;
        }
        /// <summary>
        /// Get Orders By Path - Orders for a all linked accounts.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="maxResults">Sets a max number of results to be returned</param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrdersAllAccounts(HttpClient client,  int maxResults)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/orders?maxResults={maxResults.ToString()}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Orders By Path - Orders for a all linked accounts.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="status">Specifies that only orders of this status should be returned.
        ///   acceptable values = "", AWAITING_PARENT_ORDER, AWAITING_CONDITION, AWAITING_MANUAL_REVIEW, ACCEPTED, AWAITING_UR_OUT, 
        ///     PENDING_ACTIVATION, QUEUED, WORKING, REJECTED, PENDING_CANCEL, CANCELED, PENDING_REPLACE, REPLACED, FILLED, EXPIRED
        /// </param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrdersAllAccounts(HttpClient client, string status)//, int maxResults, DateTime fromEnteredTime, DateTime toEnteredTime, string status)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/orders?status={status}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Orders By Path - Orders for a all linked accounts.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="status">Specifies that only orders of this status should be returned.
        ///   acceptable values = "", AWAITING_PARENT_ORDER, AWAITING_CONDITION, AWAITING_MANUAL_REVIEW, ACCEPTED, AWAITING_UR_OUT, 
        ///     PENDING_ACTIVATION, QUEUED, WORKING, REJECTED, PENDING_CANCEL, CANCELED, PENDING_REPLACE, REPLACED, FILLED, EXPIRED
        /// </param>
        /// <param name="maxResults">Sets a max number of results to be returned</param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrdersAllAccounts(HttpClient client, string status, int maxResults)//, DateTime fromEnteredTime, DateTime toEnteredTime, string status)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/orders?status={status}&maxResults={maxResults.ToString()}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Orders By Path - Orders for a all linked accounts.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="fromEnteredTime">Specifies that no orders entered before this time should be returned. Valid ISO-8601 formats are :
        ///  yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz Date must be within 60 days from today's date. 'toEnteredTime' must also be set.</param>
        /// <param name="toEnteredTime">Specifies that no orders entered after this time should be returned.Valid ISO-8601 formats are :
        ///  yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz. 'fromEnteredTime' must also be set.</param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrdersAllAccounts(HttpClient client,  DateTime fromEnteredTime, DateTime toEnteredTime)//, int maxResults, DateTime fromEnteredTime, DateTime toEnteredTime)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/orders?fromEnteredTime={fromEnteredTime.ToString("yyyy-MM-dd")}&toEnteredTime={toEnteredTime.ToString("yyyy-MM-dd")}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Orders By Path - Orders for a all linked accounts.
        /// </summary>
        /// <param name="client">httpClient with oAuth</param>
        /// <param name="fromEnteredTime">Specifies that no orders entered before this time should be returned. Valid ISO-8601 formats are :
        ///  yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz Date must be within 60 days from today's date. 'toEnteredTime' must also be set.</param>
        /// <param name="toEnteredTime">Specifies that no orders entered after this time should be returned.Valid ISO-8601 formats are :
        ///  yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz. 'fromEnteredTime' must also be set.</param>
        /// <param name="status">Specifies that only orders of this status should be returned.
        ///   acceptable values = "", AWAITING_PARENT_ORDER, AWAITING_CONDITION, AWAITING_MANUAL_REVIEW, ACCEPTED, AWAITING_UR_OUT, 
        ///     PENDING_ACTIVATION, QUEUED, WORKING, REJECTED, PENDING_CANCEL, CANCELED, PENDING_REPLACE, REPLACED, FILLED, EXPIRED
        /// </param>
        /// <returns>TD API HttpResponseMessage</returns>
        public static HttpResponseMessage getOrdersAllAccounts(HttpClient client, DateTime fromEnteredTime, DateTime toEnteredTime, string status)//, int maxResults, DateTime fromEnteredTime, DateTime toEnteredTime, string status)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/orders?status={status}&fromEnteredTime={fromEnteredTime.ToString("yyyy-MM-dd")}&toEnteredTime={toEnteredTime.ToString("yyyy-MM-dd")}";
            return client.GetAsync(apiURL).Result;
        }


        /// <summary> POST Place Order (live active Order) - Place an order for a specific account.</summary>
        /// <param name="client">HttpClient with oAuth</param>
        /// <param name="accountId">Account to save order to</param>
        /// <param name="saveOrder">populated order object</param>
        /// <returns></returns>
        public static HttpResponseMessage postCreateOrder(HttpClient client, string accountId, order saveOrder)
        {
            string url = $"https://api.tdameritrade.com/v1/accounts/{accountId}/orders";
            string dOrder = JsonConvert.SerializeObject(saveOrder,
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
            HttpContent content = new StringContent(dOrder, Encoding.UTF8, "application/json");
            return client.PostAsync(url, content).Result;
        }

        //PUT
        //Replace Order
        //https://api.tdameritrade.com/v1/accounts/{accountId}/orders/{orderId}
        //Replace an existing order for an account.The existing order will be replaced by the new order.Once replaced, the old order will be canceled and a new order will be created.

        #endregion
        #region Saved Orders
        //Method
        //Description


        /// <summary> POST Create Saved Order -Save an order for a specific account.</summary>
        /// <param name="client">HttpClient with oAuth</param>
        /// <param name="accountId">Account to save order to</param>
        /// <param name="saveOrder">populated order object</param>
        /// <returns></returns>
        public static HttpResponseMessage postCreateSavedOrder(HttpClient client, string accountId, order saveOrder)
        {
            string url = $"https://api.tdameritrade.com/v1/accounts/{accountId}/savedorders";
            string dOrder = JsonConvert.SerializeObject(saveOrder,
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
            HttpContent content = new StringContent(dOrder, Encoding.UTF8, "application/json");
            return client.PostAsync(url, content).Result;
        }

        //DELETE
        //Delete Saved Order
        //https://api.tdameritrade.com/v1/accounts/{accountId}/savedorders/{savedOrderId}
        //Delete a specific saved order for a specific account.

        /// <summary>
        /// Specific saved order by its ID, for a specific account.
        /// </summary>
        /// <param name="client">HttpClient with oAuth Token</param>
        /// <param name="accountId">Account number as string</param>
        /// <param name="savedOrderId">Saved Order ID</param>
        /// <returns></returns>
        public static HttpResponseMessage getSavedOrder(HttpClient client, string accountId, string savedOrderId)
        {
        string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/savedorders/{savedOrderId}";
        return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// GET Saved orders for a specific account.  Get Saved Orders by Path
        /// </summary>
        /// <param name="client">httpClient with oAuth Header</param>
        /// <param name="accountId">Account Number as String</param>
        /// <returns>API HttpResponseMessage</returns>
        public static HttpResponseMessage getSavedOrders(HttpClient client, string accountId)
        {
        string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/savedorders";
        return client.GetAsync(apiURL).Result;
        }

        //PUT
        //Replace Saved Order
        //https://api.tdameritrade.com/v1/accounts/{accountId}/savedorders/{savedOrderId}
        //Replace an existing saved order for an account. The existing saved order will be replaced by the new order.
        #endregion
        #region Accounts

        /// <summary>
        /// Account balances, positions, and orders for a specific account.
        /// </summary>
        /// <param name="client">httpClient with OAuth token</param>
        /// <param name="accountId">Account Number as a string</param>
        /// <param name="fields">Example:fields=positions,orders</param>
        /// <returns>HttpResponseMessage return object</returns>
        public static HttpResponseMessage getAccount(HttpClient client, string accountId, string fields = null)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}";
            if (!string.IsNullOrWhiteSpace(fields))
                apiURL += $"?fields={fields}";
            return client.GetAsync(apiURL).Result;
        }

        /// <summary>
        /// Get Accounts
        /// Account balances, positions, and orders for all linked accountsDescription
        /// Balances displayed by default, additional fields can be added here by adding positions or orders
        /// </summary>
        /// <param name="client">httpClient with OAuth token</param>
        /// <param name="fields">Example:fields=positions,orders</param>
        /// <returns>HttpResponseMessage return object</returns>
        public static HttpResponseMessage getAccounts(HttpClient client, string fields = null)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts";
            if(!string.IsNullOrWhiteSpace(fields))
                apiURL += $"?fields={fields}";
            return client.GetAsync(apiURL).Result;
        }

        #endregion
    }
}
 