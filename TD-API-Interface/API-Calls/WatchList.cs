using System;
using System.Collections.Generic;
using System.Text; 
using System.Net.Http;

namespace TD_API_Interface.API_Calls
{
    /// <summary>
    /// APIs to perform CRUD operations on Account Watchlist
    /// </summary>
    public static class WatchList
    {



        ////POST
        ////Create Watchlist
        ////https://api.tdameritrade.com/v1/accounts/{accountId}/watchlists
        ////Create watchlist for specific account.This method does not verify that the symbol or asset type are valid.public static HttpResponseMessage getWatchilistsforSingleAccount(HttpClient client, string accountId)
        //public static HttpResponseMessage createWatchlist(HttpClient client, string accountId)
        //{

        //    //{
        //    //    "name": "string",
        //    //    "watchlistItems": [
        //    //        {
        //    //            "quantity": 0,
        //    //            "averagePrice": 0,
        //    //            "commission": 0,
        //    //            "purchasedDate": "DateParam\"",
        //    //            "instrument": {
        //    //                "symbol": "string",
        //    //                "assetType": "'EQUITY' or 'OPTION' or 'MUTUAL_FUND' or 'FIXED_INCOME' or 'INDEX'"
        //    //            }
        //    //}
        //    //    ]
        //    //}

        //    string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/watchlists";
        //    return client.PostAsync(apiURL).Result;
        //}

        //DELETE
        //Delete Watchlist
        //https://api.tdameritrade.com/v1/accounts/{accountId}/watchlists/{watchlistId}
        //Delete watchlist for a specific account.


        /// <summary>
        /// GET - Get Watchlist - Specific watchlist for a specific account.
        /// </summary>
        /// <param name="client">HttpClient with OAuth Head</param>
        /// <param name="accountId">Td Ameritrade Account ID</param>
        /// <param name="watchlistId">Watch List ID</param>
        /// <returns>HttpResponseMessage</returns>
        public static HttpResponseMessage getWatchilist(HttpClient client, string accountId, string watchlistId)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/watchlists/{watchlistId}";
            return client.GetAsync(apiURL).Result;
        }



        /// <summary>
        /// Get All watchlists for all of the user's linked accounts 
        /// </summary>
        /// <param name="client">Client with oAuth header</param>
        /// <returns>HttpResponseMessage</returns>
        public static HttpResponseMessage getWishlistsForAllAccounts(HttpClient client)
        {
            return client.GetAsync("https://api.tdameritrade.com/v1/accounts/watchlists").Result;
        }

        /// <summary>
        /// GET - Get Watchlists for Single Account (All watchlists of an account.)
        /// </summary>
        /// <param name="client">HttpClient with OAuth header</param>
        /// <param name="accountID">Account ID with watchlists</param>
        /// <returns>HttpResponseMessage</returns>
        public static HttpResponseMessage getWatchilistsforSingleAccount(HttpClient client, string accountId)
        {
            string apiURL = $"https://api.tdameritrade.com/v1/accounts/{accountId}/watchlists";
            return client.GetAsync(apiURL).Result;
        }

        //PUT
        //Replace Watchlist
        //https://api.tdameritrade.com/v1/accounts/{accountId}/watchlists/{watchlistId}
        //Replace watchlist for a specific account.This method does not verify that the symbol or asset type are valid.

        //PATCH
        //Update Watchlist
        //https://api.tdameritrade.com/v1/accounts/{accountId}/watchlists/{watchlistId}
        //Partially update watchlist for a specific account: change watchlist name, add to the beginning/end of a watchlist, update or delete items in a watchlist. This method does not verify that the symbol or asset type are valid.

    }
}
