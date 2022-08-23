using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// Basic on TDA Get Quote Equity Output found on https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes
    /// </summary>
    public class QuoteEquity : QuoteBase
    {
        public float bidPrice { get; set; }
        public int bidSize { get; set; }
        public string bidId { get; set; }
        public float askPrice { get; set; }
        public int askSize { get; set; }
        public string askId { get; set; }
        public float lastPrice { get; set; }
        public double lastSize { get; set; }
        public string lastId { get; set; }
        public float openPrice { get; set; }
        public float highPrice { get; set; }
        public float lowPrice { get; set; }
        public float closePrice { get; set; }
        public float netChange { get; set; }
        public Int64 totalVolume { get; set; }
        public Int64 quoteTimeInLong { get; set; }
        public Int64 tradeTimeInLong { get; set; }
        public float mark { get; set; }
        public bool marginable { get; set; }
        public bool shortable { get; set; }
        public float volatility { get; set; }
        public int digits { get; set; }
        public float _52WkHigh { get; set; }
        public float _52WkLow { get; set; }
        public float peRatio { get; set; }
        public float divAmount { get; set; }
        public float divYield { get; set; }
        public string divDate { get; set; }
        public string securityStatus { get; set; }
        public float regularMarketLastPrice { get; set; }
        public int regularMarketLastSize { get; set; }
        public double regularMarketNetChange { get; set; }
        public Int64 regularMarketTradeTimeInLong { get; set; }
        public double netPercentChangeInDouble { get; set; }
        public double markChangeInDouble { get; set; }
        public double markPercentChangeInDouble { get; set; }
        public float regularMarketPercentChangeInDouble { get; set; }
    }

}
