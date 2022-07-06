using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// Basic on TDA Get Quote Option Output found on https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes
    /// </summary>
    public class QuoteOption
    {
        public string symbol { get; set; }
        public string description { get; set; }
        public int bidPrice { get; set; }
        public int bidSize { get; set; }
        public int askPrice { get; set; }
        public int askSize { get; set; }
        public int lastPrice { get; set; }
        public int lastSize { get; set; }
        public int openPrice { get; set; }
        public int highPrice { get; set; }
        public int lowPrice { get; set; }
        public int closePrice { get; set; }
        public int netChange { get; set; }
        public Int64 totalVolume { get; set; }
        public long quoteTimeInLong { get; set; }
        public long tradeTimeInLong { get; set; }
        public int mark { get; set; }
        public int openInterest { get; set; }
        public int volatility { get; set; }
        public int moneyIntrinsicValue { get; set; }
        public int multiplier { get; set; }
        public int strikePrice { get; set; }
        public string contractType { get; set; }
        public string underlying { get; set; }
        public int timeValue { get; set; }
        public string deliverables { get; set; }
        public int delta { get; set; }
        public int gamma { get; set; }
        public int theta { get; set; }
        public int vega { get; set; }
        public int rho { get; set; }
        public string securityStatus { get; set; }
        public int theoreticalOptionValue { get; set; }
        public int underlyingPrice { get; set; }
        public string uvExpirationType { get; set; }
        public string exchange { get; set; }
        public string exchangeName { get; set; }
        public string settlementType { get; set; }
    }

}
