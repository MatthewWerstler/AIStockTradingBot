using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// Basic on TDA Get Quote Future Option Output found on https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes
    /// </summary>
    public class QuoteFutureOption : QuoteBase
    {
        public double bidPriceInDouble { get; set; }
        public double askPriceInDouble { get; set; }
        public double lastPriceInDouble { get; set; }
        public double highPriceInDouble { get; set; }
        public double lowPriceInDouble { get; set; }
        public double closePriceInDouble { get; set; }
        public double openPriceInDouble { get; set; }
        public double netChangeInDouble { get; set; }
        public int openInterest { get; set; }
        public string securityStatus { get; set; }
        public int volatility { get; set; }
        public int moneyIntrinsicValueInDouble { get; set; }
        public int multiplierInDouble { get; set; }
        public int digits { get; set; }
        public double strikePriceInDouble { get; set; }
        public string contractType { get; set; }
        public string underlying { get; set; }
        public double timeValueInDouble { get; set; }
        public double deltaInDouble { get; set; }
        public double gammaInDouble { get; set; }
        public double thetaInDouble { get; set; }
        public double vegaInDouble { get; set; }
        public double rhoInDouble { get; set; }
        public int mark { get; set; }
        public int tick { get; set; }
        public int tickAmount { get; set; }
        public bool futureIsTradable { get; set; }
        public string futureTradingHours { get; set; }
        public int futurePercentChange { get; set; }
        public bool futureIsActive { get; set; }
        public long futureExpirationDate { get; set; }
        public string expirationType { get; set; }
        public string exerciseType { get; set; }
        public bool inTheMoney { get; set; }
    }

}
