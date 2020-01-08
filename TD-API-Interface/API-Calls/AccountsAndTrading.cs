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
        //Get Orders By Path

        //https://api.tdameritrade.com/v1/accounts/{accountId}/orders
        //Orders for a specific account.

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

        //GET
        //Get Saved Order


        //https://api.tdameritrade.com/v1/accounts/{accountId}/savedorders/{savedOrderId}
        //Specific saved order by its ID, for a specific account.

        //GET
        //Get Saved Orders by Path


        //https://api.tdameritrade.com/v1/accounts/{accountId}/savedorders
        //Saved orders for a specific account.

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