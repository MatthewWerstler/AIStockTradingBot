using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class QuoteDetails
    {


        public string StockTicker { get; set; }
        public QuoteFrequencies QuoteFrequency { get; set; }
        //public DateTime? FirstQuote { get; set; }
        //public DateTime? LastQuote { get; set; }
        public string FolderPath { get; set; }
        public string HistoryFolderPath { get; set; }
        public List<QuoteByTimeFile> ActiveQuoteFiles { get; set; }
        public List<QuoteByTimeFile> HistoricQuoteFiles { get; set; }

        /// <summary>
        /// Standard constructor stock ticker and quoting frequency should be known during initialization
        /// </summary>
        /// <param name="stockTicker">Stock Market Symbol</param>
        /// <param name="frequency">Quote frequency based on the defined enum list</param>
        public QuoteDetails(string stockTicker, QuoteFrequencies frequency)
        {
            StockTicker = stockTicker;
            QuoteFrequency = frequency;
        }
         

    }

    public enum QuoteFrequencies
    {
        ByMinute,
        ByFifteenMinutes,
        ByThirtyMinutes,
        ByHour,
        ByDay,
        ByWeek,
        ByMonth
    }
}
