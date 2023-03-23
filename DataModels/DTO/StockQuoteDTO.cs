using System;

namespace DataModels.DTO
{
    public class StockQuoteDTO
    {
        public DateTime date { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public Int64 volume { get; set; }
    }
}
