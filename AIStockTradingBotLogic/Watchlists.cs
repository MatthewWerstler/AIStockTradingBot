using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace AIStockTradingBotLogic
{
    public static class Watchlists
    {
        public static DataModels.AllWatchLists GetAllWatchLists(HttpClient client)
        {
            var results = TD_API_Interface.API_Calls.WatchList.getWishlistsForAllAccounts(client);
            var contents = results.Content.ReadAsStringAsync().Result;
            return  new DataModels.AllWatchLists(contents);
        }
    }
}
