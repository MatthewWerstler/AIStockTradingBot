using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{

    public class Rootobject
    {
        public string session { get; set; }
        public string duration { get; set; }
        public string orderType { get; set; }
        public string complexOrderStrategyType { get; set; }
        public float quantity { get; set; }
        public float filledQuantity { get; set; }
        public float remainingQuantity { get; set; }
        public string requestedDestination { get; set; }
        public string destinationLinkName { get; set; }
        public float price { get; set; }
        public Orderlegcollection[] orderLegCollection { get; set; }
        public string orderStrategyType { get; set; }
        public int orderId { get; set; }
        public bool cancelable { get; set; }
        public bool editable { get; set; }
        public string status { get; set; }
        public DateTime enteredTime { get; set; }
        public DateTime closeTime { get; set; }
        public string tag { get; set; }
        public int accountId { get; set; }
        public Orderactivitycollection[] orderActivityCollection { get; set; }
        public Childorderstrategy[] childOrderStrategies { get; set; }
    }

    public class Orderlegcollection
    {
        public string orderLegType { get; set; }
        public int legId { get; set; }
        public Instrument instrument { get; set; }
        public string instruction { get; set; }
        public string positionEffect { get; set; }
        public float quantity { get; set; }
    }

    public class Instrument
    {
        public string assetType { get; set; }
        public string cusip { get; set; }
        public string symbol { get; set; }
    }

    public class Orderactivitycollection
    {
        public string activityType { get; set; }
        public string executionType { get; set; }
        public float quantity { get; set; }
        public float orderRemainingQuantity { get; set; }
        public Executionleg[] executionLegs { get; set; }
    }

    public class Executionleg
    {
        public int legId { get; set; }
        public float quantity { get; set; }
        public float mismarkedQuantity { get; set; }
        public float price { get; set; }
        public DateTime time { get; set; }
    }

    public class Childorderstrategy
    {
        public string session { get; set; }
        public string duration { get; set; }
        public string orderType { get; set; }
        public string cancelTime { get; set; }
        public string complexOrderStrategyType { get; set; }
        public float quantity { get; set; }
        public float filledQuantity { get; set; }
        public float remainingQuantity { get; set; }
        public string requestedDestination { get; set; }
        public string destinationLinkName { get; set; }
        public float price { get; set; }
        public Orderlegcollection1[] orderLegCollection { get; set; }
        public string orderStrategyType { get; set; }
        public int orderId { get; set; }
        public bool cancelable { get; set; }
        public bool editable { get; set; }
        public string status { get; set; }
        public DateTime enteredTime { get; set; }
        public string tag { get; set; }
        public int accountId { get; set; }
    }

    public class Orderlegcollection1
    {
        public string orderLegType { get; set; }
        public int legId { get; set; }
        public Instrument1 instrument { get; set; }
        public string instruction { get; set; }
        public string positionEffect { get; set; }
        public float quantity { get; set; }
    }

    public class Instrument1
    {
        public string assetType { get; set; }
        public string cusip { get; set; }
        public string symbol { get; set; }
    }

}
