using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    /// <summary>
    /// TDA Quotes by Minute, Day, etc
    /// </summary>
    public class Quote
    {
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public Int64 volume { get; set; }
        public long datetime { get; set; }
    }

    public class CompareQuoteByDatetime : IEqualityComparer<DataModels.Quote>
    {
        public bool Equals(DataModels.Quote x, DataModels.Quote y)
        {
            return x.datetime == y.datetime;
        }

        public int GetHashCode(DataModels.Quote obj)
        {
            return obj.datetime.GetHashCode();
        }
    }
}
