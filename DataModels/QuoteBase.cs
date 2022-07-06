using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class QuoteBase
    {
        public string assetType { get; set; }
        public string assetMainType { get; set; }
        public string cusip { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public string exchange { get; set; }
        public string exchangeName { get; set; }
        public bool delayed { get; set; }
        public bool realtimeEntitled { get; set; }
    }
}
