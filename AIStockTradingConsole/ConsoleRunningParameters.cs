using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using DataModels;
using Microsoft.Extensions.Configuration;

namespace AIStockTradingConsole
{
    public class ConsoleRunningParameters
    {
       

        public HttpClient client { get; set; }
        public string apiKey { get; set; }
        public string tradeDataPath { get; set; }
        public DateTime StartTime { get; set; }

        public List<DataModels.Account> accounts { get; set; }

        #region "Equality Stock Market Session Information"
        public Sessionhours sessionhours { get; set; }
        public string currentSession 
        { 
            get
            {
                string cSession = AIStockTradingBotLogic.Market.currentSession(sessionhours, DateTime.Now);
                if (cSession == "resetSession")
                { 
                    sessionhours = AIStockTradingBotLogic.Market.getEquityMarketHours(client, DateTime.Now);
                    cSession = AIStockTradingBotLogic.Market.currentSession(sessionhours, DateTime.Now);
                }
                return cSession;
            }
        }
        #endregion

        #region Constructor and logic
        public ConsoleRunningParameters()
        {
            StartTime = DateTime.Now;
            Console.WriteLine($"StartTime {StartTime.ToString()}");

            //Populate Secretes
            //Get Secretes
            var builder = new ConfigurationBuilder()
                            .AddUserSecrets<Program>();
            IConfiguration Configuration = builder.Build();
            apiKey = Configuration["Consumer_Key"];
            //string _account01 = Configuration["Account01"];
            tradeDataPath = Configuration["TradingDataPath"];
            accounts = new List<Account>();
            //Create Account Objects
            bool boolBreak = false;
            int i = 0;
            do
            {
                var number = Configuration[$"Accounts:{i}:Number"];
                if (string.IsNullOrWhiteSpace(number))
                {
                    boolBreak = true;
                    break;
                }
                var isActivelyTrading = Configuration[$"Accounts:{i}:isActivelyTrading"];
                Account thisAccount = new Account(number);
                thisAccount.isActivelyTrading = isActivelyTrading.ToLower() == "true" ? true : false;
                accounts.Add(thisAccount);
                i++;
            }
            while (!boolBreak);
            Log.write($"settings built");

            //Get HttpClient
            client = new HttpClient();
            getAndSetAuthToken(client, Configuration["refresh_token"], apiKey);
            Log.write($"HttpClient OAuth set");

            //Hydrate Accounts 
            foreach (Account act in accounts)
            {
                AIStockTradingBotLogic.AccountHydrate.getWishLists(client, act);
                MarketHistory.ReadWriteJSONToDisk.writeDataAsJSON($"{tradeDataPath}\\{act.AccountId}.json", act);
            }
        }
        public static void getAndSetAuthToken(System.Net.Http.HttpClient client, string refresh_token, string Consumer_Key)
        {
            //var message = TD_API_Interface.API_Calls.Authentication.refreshToken(client, refresh_token, Consumer_Key);
            string Authorization = TD_API_Interface.API_Calls.Authentication.refreshToken(client, refresh_token, Consumer_Key);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authorization);
        }
        #endregion
    }
}
