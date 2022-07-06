using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// Basic on TDA Get Quote Index Output found on https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes
    /// </summary>
    public class QuoteIndex : QuoteBase
    {
        public double lastPrice { get; set; }
        public double openPrice { get; set; }
        public double highPrice { get; set; }
        public double lowPrice { get; set; }
        public double closePrice { get; set; }
        public double netChange { get; set; }
        public Int64 totalVolume { get; set; }
        public long tradeTimeInLong { get; set; }
        public int digits { get; set; }
        public double _52WkHigh { get; set; }
        public double _52WkLow { get; set; }
        public string securityStatus { get; set; }
    }

}
