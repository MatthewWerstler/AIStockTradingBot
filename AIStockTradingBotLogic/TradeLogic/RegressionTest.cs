using System;
using System.Collections.Generic;
using System.Text;
using AIStockTradingBotLogic.TradeLogic;

namespace AIStockTradingBotLogic
{
    public class RegressionTest
    {
        /// <summary>
        /// Begin Regression at this time
        /// </summary>
        public DateTime startDateTime { get; set; }
        /// <summary>
        /// End Regression Test at this time
        /// </summary>
        public DateTime endDateTime { get; set; }
        /// <summary>
        /// The time the Regression Test is acting on
        /// </summary>
        public DateTime currentRegressionDateTime { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="start">Test From Date</param>
        /// <param name="end">Test To Date</param>
        /// <param name="increment">TimeSpan increments between the from to date</param>
        /// <param name="testLogic">Trade Logic being Tested</param>
        public RegressionTest(DateTime start, DateTime end, TimeSpan increment, iTradeLogic testLogic, bool MarketHoursOnly)
        {
            currentRegressionDateTime = start;
        }
    }
}
