using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using DataModels;
using System.Globalization;

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
            string strSH = null;
            try
            {
                strSH = JsonConvert.SerializeObject(mh.equity.equity.sessionHours);
            }
            catch
            { 
                strSH = JsonConvert.SerializeObject(mh.equity.EQ.sessionHours);
            }
            Sessionhours sessionhours = JsonConvert.DeserializeObject<Sessionhours>(strSH);
            return sessionhours;
        }

        /// <summary>
        /// Returns what session the march is in of resetSession if the session hours are for the wrong date
        /// </summary>
        /// <param name="sessionHours">sessionHours DataModel object</param>
        /// <param name="referenceDateTime">DateTime</param>
        /// <returns>"preMarket", "regularMarket", "postMarket", "outsideMarket", or "resetSession" if the dates do not match</returns>
        public static string currentSession(Sessionhours sessionHours, DateTime referenceDateTime)
        {
            if (sessionHours == null)
                return "nonMarketDay"; 
            else if (referenceDateTime >= sessionHours.preMarket[0].start && referenceDateTime <= sessionHours.preMarket[0].end)
                return "preMarket";
            else if (referenceDateTime >= sessionHours.regularMarket[0].start && referenceDateTime <= sessionHours.regularMarket[0].end)
                return "regularMarket";
            else if (referenceDateTime >= sessionHours.postMarket[0].start && referenceDateTime <= sessionHours.postMarket[0].end)
                return "postMarket";
            else if (referenceDateTime.Day != sessionHours.postMarket[0].end.Day)
                return "resetSession";
            else
                return "outsideMarket";            
        }

    }
}
