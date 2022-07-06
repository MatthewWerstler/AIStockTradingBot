using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// Basic on TDA Get Quote Option Output found on https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes
    /// </summary>
    public class QuoteOption : QuoteBase
    {
        public double bidPrice { get; set; }
        public int bidSize { get; set; }
        public double askPrice { get; set; }
        public int askSize { get; set; }
        public double lastPrice { get; set; }
        public double lastSize { get; set; }
        public double openPrice { get; set; }
        public double highPrice { get; set; }
        public double lowPrice { get; set; }
        public double closePrice { get; set; }
        public double netChange { get; set; }
        public Int64 totalVolume { get; set; }
        public long quoteTimeInLong { get; set; }
        public long tradeTimeInLong { get; set; }
        public float mark { get; set; }
        public double opendoubleerest { get; set; }
        public double volatility { get; set; }
        public double moneydoublerinsicValue { get; set; }
        public double multiplier { get; set; }
        public double strikePrice { get; set; }
        public string contractType { get; set; }
        public string underlying { get; set; }
        public double timeValue { get; set; }
        public string deliverables { get; set; }
        public double delta { get; set; }
        public double gamma { get; set; }
        public double theta { get; set; }
        public double vega { get; set; }
        public double rho { get; set; }
        public string securityStatus { get; set; }
        public double theoreticalOptionValue { get; set; }
        public double underlyingPrice { get; set; }
        public string uvExpirationType { get; set; }
        public string settlementType { get; set; }
    }

}
