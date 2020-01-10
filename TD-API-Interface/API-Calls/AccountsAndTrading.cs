using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

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

        //DELETE
        //Cancel Order

        //https://api.tdameritrade.com/v1/accounts/{accountId}/orders/{orderId}
        //Cancel a specific order for a specific account.

        //GET
        //Get Order

        //https://api.tdameritrade.com/v1/accounts/{accountId}/orders/{orderId}
        //Get a specific order for a specific account.

        //GET
        //
        //Query Parameters
        //Name   
        // Description
        //maxResults        
        //  The maximum number of orders to retrieve.
        //fromEnteredTime
        //  Specifies that no orders entered before this time should be returned. Valid ISO-8601 formats are :
        //  yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz Date must be within 60 days from today's date. 'toEnteredTime' must also be set.
        //toEnteredTime
        //  Specifies that no orders entered after this time should be returned.Valid ISO-8601 formats are :
        //  yyyy-MM-dd and yyyy-MM-dd'T'HH:mm:ssz. 'fromEnteredTime' must also be set.
        //status
        //  Specifies that only orders of this status should be returned.
        /*
                                <option value="">(no value)</option>
                                <option value="AWAITING_PARENT_ORDER">AWAITING_PARENT_ORDER</option>
                                <option value="AWAITING_CONDITION">AWAITING_CONDITION</option>
                                <option value="AWAITING_MANUAL_REVIEW">AWAITING_MANUAL_REVIEW</option>
                                <option value="ACCEPTED">ACCEPTED</option>
                                <option value="AWAITING_UR_OUT">AWAITING_UR_OUT</option>
                                <option value="PENDING_ACTIVATION">PENDING_ACTIVATION</option>
                                <option value="QUEUED">QUEUED</option>
                                <option value="WORKING">WORKING</option>
                                <option value="REJECTED">REJECTED</option>
                                <option value="PENDING_CANCEL">PENDING_CANCEL</option>
                                <option value="CANCELED">CANCELED</option>
                                <option value="PENDING_REPLACE">PENDING_REPLACE</option>
                                <option value="REPLACED">REPLACED</option>
                                <option value="FILLED">FILLED</option>
                                <option value="EXPIRED">EXPIRED</option>
        */
        //ends Query Parameters
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

        //POST
        //Place Order

        //https://api.tdameritrade.com/v1/accounts/{accountId}/orders
        //Place an order for a specific account.

        //PUT
        //Replace Order

        //https://api.tdameritrade.com/v1/accounts/{accountId}/orders/{orderId}
        //Replace an existing order for an account.The existing order will be replaced by the new order.Once replaced, the old order will be canceled and a new order will be created.

        #endregion
        #region Saved Orders
        //Method
        //Description

        //POST
        //Create Saved Order
        //https://api.tdameritrade.com/v1/accounts/{accountId}/savedorders
        //Save an order for a specific account.

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
        public static HttpResponseMessage getSavedOrders(HttpClient client, string accountId, string savedOrderId)
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
        public static HttpResponseMessage getAccount(HttpClient client, string accountId, string fields)
        {
        string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}?fields={fields}";
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
        public static HttpResponseMessage getAccounts(HttpClient client, string fields)
        {
        string apiURL = $"https://api.tdameritrade.com/v1/accounts?fields={fields}";
        return client.GetAsync(apiURL).Result;
        }

        #endregion
    }
}
 