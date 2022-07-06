using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// Basic on TDA Get Quote ETF Output found on https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes
    /// </summary>
    public class QuoteETF
    {
        public string symbol { get; set; }
        public string description { get; set; }
        public int bidPrice { get; set; }
        public int bidSize { get; set; }
        public string bidId { get; set; }
        public int askPrice { get; set; }
        public int askSize { get; set; }
        public string askId { get; set; }
        public int lastPrice { get; set; }
        public int lastSize { get; set; }
        public string lastId { get; set; }
        public int openPrice { get; set; }
        public int highPrice { get; set; }
        public int lowPrice { get; set; }
        public int closePrice { get; set; }
        public int netChange { get; set; }
        public Int64 totalVolume { get; set; }
        public long quoteTimeInLong { get; set; }
        public long tradeTimeInLong { get; set; }
        public int mark { get; set; }
        public string exchange { get; set; }
        public string exchangeName { get; set; }
        public bool marginable { get; set; }
        public bool shortable { get; set; }
        public int volatility { get; set; }
        public int digits { get; set; }
        public int _52WkHigh { get; set; }
        public int _52WkLow { get; set; }
        public int peRatio { get; set; }
        public int divAmount { get; set; }
        public int divYield { get; set; }
        public string divDate { get; set; }
        public string securityStatus { get; set; }
        public int regularMarketLastPrice { get; set; }
        public int regularMarketLastSize { get; set; }
        public int regularMarketNetChange { get; set; }
        public int regularMarketTradeTimeInLong { get; set; }
    }

}
