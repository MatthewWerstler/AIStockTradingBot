using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// Basic on TDA Get Quote Forex Output found on https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes
    /// </summary>
    public class QuoteForex
    {
        public string symbol { get; set; }
        public int bidPriceInDouble { get; set; }
        public int askPriceInDouble { get; set; }
        public int lastPriceInDouble { get; set; }
        public int highPriceInDouble { get; set; }
        public int lowPriceInDouble { get; set; }
        public int closePriceInDouble { get; set; }
        public string exchange { get; set; }
        public string description { get; set; }
        public int openPriceInDouble { get; set; }
        public int changeInDouble { get; set; }
        public int percentChange { get; set; }
        public string exchangeName { get; set; }
        public int digits { get; set; }
        public string securityStatus { get; set; }
        public int tick { get; set; }
        public int tickAmount { get; set; }
        public string product { get; set; }
        public string tradingHours { get; set; }
        public bool isTradable { get; set; }
        public string marketMaker { get; set; }
        public int _52WkHighInDouble { get; set; }
        public int _52WkLowInDouble { get; set; }
        public int mark { get; set; }
    }

}
