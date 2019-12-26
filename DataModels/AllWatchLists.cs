using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataModels
{
    /// <summary>
    /// TD Ameritrade Based AllWatchLists (Partically simplified) 
    /// </summary>
    public class AllWatchLists
    {
        public List<WatchList> Lists { get; set; }

        public AllWatchLists(string stringJSON)
        {
            dynamic data = JsonConvert.DeserializeObject(stringJSON);
            Lists = new List<WatchList>();
            foreach (dynamic wlist in data)
            {
                WatchList thisList = new WatchList(wlist);                
                Lists.Add(thisList);
            }
        }
    }

        public class WatchList
        {
            public WatchList(dynamic list)
            {
                name = list.name;
                watchlistId = list.watchlistId;
                accountId = list.accountId;
                watchlistItems = new List<Watchlistitem>();
                foreach (dynamic item in list.watchlistItems)
                {
                    Watchlistitem thisList = new Watchlistitem(item);
                    watchlistItems.Add(thisList);
                }
            }
            public string name { get; set; }
            public string watchlistId { get; set; }
            public string accountId { get; set; }
            public List<Watchlistitem> watchlistItems { get; set; }
        }

        public class Watchlistitem
        {
            public int sequenceId { get; set; }
            public float quantity { get; set; }
            public float averagePrice { get; set; }
            public float commission { get; set; }
            public string symbol { get; set; }
            public string assetType { get; set; }
            public Watchlistitem(dynamic item)
            {
                sequenceId = item.sequenceId;
                quantity = item.quantity;
                averagePrice = item.averagePrice;
                commission = item.commission;
                symbol = item.instrument.symbol;
                assetType = item.instrument.assetType;
            }
        }

      

}
