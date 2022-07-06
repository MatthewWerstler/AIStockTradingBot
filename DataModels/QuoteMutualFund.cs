using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// Basic on TDA Get Quote Mutual Fund Output found on https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes
    /// </summary>
    public class QuoteMutualFund : QuoteBase
    {
        public double closePrice { get; set; }
        public float netChange { get; set; }
        public Int64 totalVolume { get; set; }
        public long tradeTimeInLong { get; set; }
        public int digits { get; set; }
        public double _52WkHigh { get; set; }
        public double _52WkLow { get; set; }
        public double nAV { get; set; }
        public float peRatio { get; set; }
        public double divAmount { get; set; }
        public double divYield { get; set; }
        public string divDate { get; set; }
        public string securityStatus { get; set; }
        public double netPercentChangeInDouble { get; set; }
    }

}
