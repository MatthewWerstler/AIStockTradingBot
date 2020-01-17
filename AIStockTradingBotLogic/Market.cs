using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using DataModels;

namespace AIStockTradingBotLogic
{
    public static class Market
    {
        public static DataModels.Sessionhours getEquityMarketHours(HttpClient client, DateTime date)
        {
            string market = "EQUITY";
            var response = TD_API_Interface.API_Calls.MarketHours.getHoursForMarket(client, market, date);
            var content = response.Content.ReadAsStringAsync().Result;
            dynamic mh = JsonConvert.DeserializeObject(content);
            string strSH = JsonConvert.SerializeObject(mh.equity.EQ.sessionHours);
            Sessionhours sessionhours = JsonConvert.DeserializeObject<Sessionhours>(strSH);
            return sessionhours;
        }

    }
}
