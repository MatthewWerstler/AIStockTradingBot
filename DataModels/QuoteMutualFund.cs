using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// Basic on TDA Get Quote Mutual Fund Output found on https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes
    /// </summary>
    public class QuoteMutualFund
    {
        public string symbol { get; set; }
        public string description { get; set; }
        public double closePrice { get; set; }
        public int netChange { get; set; }
        public Int64 totalVolume { get; set; }
        public long tradeTimeInLong { get; set; }
        public string exchange { get; set; }
        public string exchangeName { get; set; }
        public int digits { get; set; }
        public int _52WkHigh { get; set; }
        public int _52WkLow { get; set; }
        public int nAV { get; set; }
        public int peRatio { get; set; }
        public double divAmount { get; set; }
        public double divYield { get; set; }
        public string divDate { get; set; }
        public string securityStatus { get; set; }
    }

}
