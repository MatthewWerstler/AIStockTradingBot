using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataModels
{

    public class MarketHours
    {
        public string date { get; set; }
        public string marketType { get; set; }
        public string exchange { get; set; }
        public string category { get; set; }
        public string product { get; set; }
        public string productName { get; set; }
        public bool isOpen { get; set; }
        public Sessionhours sessionHours { get; set; }
    }

    public class Sessionhours
    {
        public Premarket[] preMarket { get; set; }
        public Regularmarket[] regularMarket { get; set; }
        public Postmarket[] postMarket { get; set; }
    }

    public class Premarket
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }

    public class Regularmarket
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }

    public class Postmarket
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }

}
