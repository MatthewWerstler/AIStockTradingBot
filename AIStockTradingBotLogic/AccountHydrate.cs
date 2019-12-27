using System;
using System.Net.Http;
using DataModels;

namespace AIStockTradingBotLogic
{
    public static class AccountHydrate
    {
        public static void getWishLists(HttpClient client, Account thisAccount)
        {
            var results = TD_API_Interface.API_Calls.WatchList.getWatchilistsforSingleAccount(client, thisAccount.AccountId);
            if(results.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contents = results.Content.ReadAsStringAsync().Result;
                thisAccount.WatchLists = new DataModels.AllWatchLists(contents).Lists; 
            }
        }

    }
}
