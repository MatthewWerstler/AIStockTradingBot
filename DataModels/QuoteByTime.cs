using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// TDA Quotes by Minute, Day, etc
    /// </summary>
    public class QuoteByTime
    {
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public Int64 volume { get; set; }
        public long datetime { get; set; }
    }

    public class CompareQuoteByDatetime : IEqualityComparer<DataModels.QuoteByTime>
    {
        public bool Equals(DataModels.QuoteByTime x, DataModels.QuoteByTime y)
        {
            return x.datetime == y.datetime;
        }

        public int GetHashCode(DataModels.QuoteByTime obj)
        {
            return obj.datetime.GetHashCode();
        }
    }
}
