using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// Basic on TDA Get Quote Future Output found on https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes
    /// </summary>
    public class QuoteFuture : QuoteBase
    {
        public double bidPriceInDouble { get; set; }
        public double askPriceInDouble { get; set; }
        public double lastPriceInDouble { get; set; }
        public string bidId { get; set; }
        public string askId { get; set; }
        public double highPriceInDouble { get; set; }
        public double lowPriceInDouble { get; set; }
        public double closePriceInDouble { get; set; }
        public string lastId { get; set; }
        public double openPriceInDouble { get; set; }
        public double changeInDouble { get; set; }
        public int futurePercentChange { get; set; }
        public string securityStatus { get; set; }
        public int openInterest { get; set; }
        public int mark { get; set; }
        public int tick { get; set; }
        public int tickAmount { get; set; }
        public string product { get; set; }
        public string futurePriceFormat { get; set; }
        public string futureTradingHours { get; set; }
        public bool futureIsTradable { get; set; }
        public int futureMultiplier { get; set; }
        public bool futureIsActive { get; set; }
        public double futureSettlementPrice { get; set; }
        public string futureActiveSymbol { get; set; }
        public string futureExpirationDate { get; set; }
    }

}
