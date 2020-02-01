using System;
using System.Collections.Generic;
using System.Text;

namespace TD_API_Interface.PostModels
{
    /// <summary>
    /// Mapping the JSON object to class which TDA expects to create order
    /// </summary>
    public class order
    {
        private string Session = "NORMAL";
        /// <summary> session = "NORMAL", "AM", "PM", "SEAMLESS" Default = "NORMAL"</summary>
        public string session
        {
            get => Session;
            set
            {
                List<string> limitStrings = new List<string> { "NORMAL", "AM", "PM", "SEAMLESS" };
                if (limitStrings.Contains(value))
                    Session = value;
            }
        }

        private string Duration = "Day";
        /// <summary>duration = "DAY", "GOOD_TILL_CANCEL", or "FILL_OR_KILL"} Default = "Day"</summary>
        public string duration
        {
            get => Duration;
            set
            {
                List<string> limitStrings = new List<string> { "DAY", "GOOD_TILL_CANCEL", "FILL_OR_KILL" };
                if (limitStrings.Contains(value))
                    Duration = value;
            }
        }

        private string Ordertype = "LIMIT";
        /// <summary>  orderType = "MARKET", "LIMIT", "STOP", "STOP_LIMIT", "TRAILING_STOP", "MARKET_ON_CLOSE", "EXERCISE", "TRAILING_STOP_LIMIT", "NET_DEBIT", "NET_CREDIT", or "NET_ZERO" 
        /// Default = "LIMIT"</summary>
        public string orderType {
            get => Ordertype;
            set
            {
                List<string> limitStrings = new List<string> { "MARKET", "LIMIT", "STOP", "STOP_LIMIT", "TRAILING_STOP", "MARKET_ON_CLOSE", "EXERCISE", "TRAILING_STOP_LIMIT", "NET_DEBIT", "NET_CREDIT", "NET_ZERO" };
                if (limitStrings.Contains(value))
                    Ordertype = value;
            }
        }

        private string Canceltime { get; set; }
        /// <summary> cancelTime "date": "string", "shortFormat": false </summary>
        public string cancelTime { get => Canceltime; set => Canceltime = value; }

        private string Complexorderstrategytype = "NONE";
        /// <summary>
        /// complexOrderStrategyType = "NONE", "COVERED",  "VERTICAL", "BACK_RATIO", "CALENDAR","DIAGONAL","STRADDLE",
        /// "STRANGLE","COLLAR_SYNTHETIC", "BUTTERFLY", "CONDOR", "IRON_CONDOR", "VERTICAL_ROLL", "COLLAR_WITH_STOCK",
        /// "DOUBLE_DIAGONAL", "UNBALANCED_BUTTERFLY", "UNBALANCED_CONDOR", "UNBALANCED_IRON_CONDOR", "UNBALANCED_VERTICAL_ROLL",
        ///  or "CUSTOM"
        ///  Default = "NONE"
        /// </summary>
        public string complexOrderStrategyType
        {
            get => Complexorderstrategytype;
            set
            {
                List<string> limitStrings = new List<string> { "NONE", "COVERED",  "VERTICAL", "BACK_RATIO", "CALENDAR","DIAGONAL",
                    "STRADDLE", "STRANGLE","COLLAR_SYNTHETIC", "BUTTERFLY", "CONDOR", "IRON_CONDOR", "VERTICAL_ROLL", "COLLAR_WITH_STOCK",
                    "DOUBLE_DIAGONAL", "UNBALANCED_BUTTERFLY", "UNBALANCED_CONDOR", "UNBALANCED_IRON_CONDOR", "UNBALANCED_VERTICAL_ROLL",
                    "CUSTOM" };
                if (limitStrings.Contains(value))
                    Complexorderstrategytype = value;
            }
        }

        public double quantity { get; set; }
        public double filledQuantity { get; set; }
        public double remainingQuantity { get; set; }

        private string Requesteddestination;
        /// <summary>requestedDestination = "INET", "ECN_ARCA", "CBOE", "AMEX", "PHLX", "ISE", "BOX","NYSE", "NASDAQ", "BATS", 
        ///     "C2", or "AUTO" </summary>
        public string requestedDestination
        {
            get => Requesteddestination;
            set
            {
                List<string> limitStrings = new List<string> {"INET", "ECN_ARCA", "CBOE", "AMEX", "PHLX", "ISE", "BOX",
                    "NYSE", "NASDAQ", "BATS", "C2", "AUTO" };
                if (limitStrings.Contains(value))
                    Requesteddestination = value;
            }
        }

        public string destinationLinkName { get; set; }

        /// <summary>"type": "string", "format": "date-time"</summary>
        public string releaseTime { get; set; }

        public double stopPrice { get; set; }

        private string Stoppricelinkbasis;
        /// <summary>
        /// stopPriceLinkBasis = "MANUAL", "BASE", "TRIGGER", "LAST", "BID", "ASK", "ASK_BID", "MARK", "AVERAGE"
        /// </summary>
        public string stopPriceLinkBasis
        {
            get => Stoppricelinkbasis;
            set
            {
                List<string> limitStrings = new List<string> { "MANUAL", "BASE", "TRIGGER", "LAST", "BID", "ASK", "ASK_BID", "MARK", "AVERAGE" };
                if (limitStrings.Contains(value))
                    Stoppricelinkbasis = value;
            }
        }

        private string Stoppricelinktype;
        /// <summary>stopPriceLinkType = "VALUE", "PERCENT", or "TICK" </summary>
        public string stopPriceLinkType
        {
            get => Stoppricelinktype;
            set
            {
                List<string> limitStrings = new List<string> { "VALUE", "PERCENT", "TICK" };
                if (limitStrings.Contains(value))
                    Stoppricelinktype = value;
            }
        }

        public double stopPriceOffset { get; set; }

        private string Stoptype;
        /// <summary> stopType = "STANDARD", "BID", "ASK", "LAST", or "MARK"</summary>
        public string stopType
        {
            get => Stoptype;
            set
            {
                List<string> limitStrings = new List<string> { "STANDARD", "BID", "ASK", "LAST", "MARK" };
                if (limitStrings.Contains(value))
                    Stoptype = value;
            }
        }

        private string Pricelinkbasis;
        /// <summary>priceLinkBasis = "MANUAL", "BASE", "TRIGGER", "LAST", "BID","ASK", "ASK_BID", "MARK", OR "AVERAGE"</summary>
        public string priceLinkBasis
        {
            get => Pricelinkbasis;
            set
            {
                List<string> limitStrings = new List<string> { "MANUAL", "BASE", "TRIGGER", "LAST", "BID", "ASK", "ASK_BID", "MARK", "AVERAGE" };
                if (limitStrings.Contains(value))
                    Pricelinkbasis = value;
            }
        }

        private string Pricelinktype;
        /// <summary>priceLinkType = "VALUE", "PERCENT", or "TICK"</summary>
        public string priceLinkType
        {
            get => Pricelinktype;
            set
            {
                List<string> limitStrings = new List<string> { "VALUE", "PERCENT", "TICK" };
                if (limitStrings.Contains(value))
                    Pricelinktype = value;
            }
        }

        public double price { get; set; }

        private string Taxlotmethod;
        /// <summary>
        /// taxLotethod = "FIFO", "LIFO", "HIGH_COST", "LOW_COST", "AVERAGE_COST", "SPECIFIC_LOT";
        /// </summary>
        public string taxLotMethod 
        { 
            get => Taxlotmethod; 
            set
            {
                List<string> limitStrings = new List<string> { "FIFO", "LIFO", "HIGH_COST", "LOW_COST", "AVERAGE_COST", "SPECIFIC_LOT" };
                if (limitStrings.Contains(value))
                    Taxlotmethod = value;
            }
         
        }

        public Orderlegcollection orderLegCollection { get; set; }

        public double activationPrice { get; set; }

        private string Specialinstruction = "DO_NOT_REDUCE";
        /// <summary>specialInstruction = "ALL_OR_NONE", "DO_NOT_REDUCE", or "ALL_OR_NONE_DO_NOT_REDUCE"</summary>
        public string specialInstruction
        {
            get => Specialinstruction;
            set
            {
                List<string> limitStrings = new List<string> {"ALL_OR_NONE", "DO_NOT_REDUCE", "ALL_OR_NONE_DO_NOT_REDUCE"};
                if (limitStrings.Contains(value))                    
                    Specialinstruction = value;
             }
        }

        private string Orderstrategytype;
        public string orderStrategyType 
        { 
            get => Orderstrategytype; 
            set
            {
                List<string> limitStrings = new List<string> {"SINGLE", "OCO", "TRIGGER"};
                if (limitStrings.Contains(value))
                    Orderstrategytype = value;
            }
        }
        public Int64 orderId { get; set; }

        public bool cancelable { get; set; } = true;

        public bool editable { get; set; } = true;

        private string Status;
        /// <summary>
        /// status = "AWAITING_PARENT_ORDER", "AWAITING_CONDITION", "AWAITING_MANUAL_REVIEW",
        /// "ACCEPTED", "AWAITING_UR_OUT", "PENDING_ACTIVATION", "QUEUED", "WORKING", "REJECTED", "PENDING_CANCEL",
        /// "CANCELED", "PENDING_REPLACE", "REPLACED", "FILLED", or "EXPIRED" 
        /// </summary>
        public string status 
        { 
            get => Status; 
            set
            {
                List<string> limitStrings = new List<string> { "AWAITING_PARENT_ORDER", "AWAITING_CONDITION", "AWAITING_MANUAL_REVIEW",
                    "ACCEPTED", "AWAITING_UR_OUT", "PENDING_ACTIVATION", "QUEUED", "WORKING", "REJECTED", "PENDING_CANCEL",
                    "CANCELED", "PENDING_REPLACE", "REPLACED", "FILLED", "EXPIRED" };
                if (limitStrings.Contains(value))
                    Status = value;
            }
        }

        /// <summary>
        ///  enteredTime = "type": "string", "format": "date-time"
        /// </summary>
        public string enteredTime { get; set; }

        /// <summary>
        ///  closeTime = "type": "string", "format": "date-time"
        /// </summary>
        public string closeTime { get; set; }

        public string tag { get; set; }

        public Int64 accountId { get; set; }

        public Orderactivitycollection orderActivityCollection { get; set; }
        public Replacingordercollection replacingOrderCollection { get; set; }
        public Childorderstrategies childOrderStrategies { get; set; }

        public string statusDescription { get; set; }
    }



public class Orderlegcollection
{
    public string type { get; set; }
    public Items items { get; set; }
}

public class Items
{
    public string type { get; set; }
    public Properties1 properties { get; set; }
}

public class Properties1
{
    public Orderlegtype orderLegType { get; set; }
    public Legid legId { get; set; }
    public Instrument instrument { get; set; }
    public Instruction instruction { get; set; }
    public Positioneffect positionEffect { get; set; }
    public Quantity1 quantity { get; set; }
    public Quantitytype quantityType { get; set; }
}

public class Orderlegtype
{
    public string type { get; set; }
    public string[] _enum { get; set; }
}

public class Legid
{
    public string type { get; set; }
    public string format { get; set; }
}

public class Instrument
{
    public string type { get; set; }
    public string discriminator { get; set; }
    public Properties2 properties { get; set; }
}

public class Properties2
{
    public Assettype assetType { get; set; }
    public Cusip cusip { get; set; }
    public Symbol symbol { get; set; }
    public Description description { get; set; }
}

public class Assettype
{
    public string type { get; set; }
    public string[] _enum { get; set; }
}

public class Cusip
{
    public string type { get; set; }
}

public class Symbol
{
    public string type { get; set; }
}

public class Description
{
    public string type { get; set; }
}

public class Instruction
{
    public string type { get; set; }
    public string[] _enum { get; set; }
}

public class Positioneffect
{
    public string type { get; set; }
    public string[] _enum { get; set; }
}

public class Quantity1
{
    public string type { get; set; }
    public string format { get; set; }
}

public class Quantitytype
{
    public string type { get; set; }
    public string[] _enum { get; set; }
}





public class Enteredtime
{
    public string type { get; set; }
    public string format { get; set; }
}


public class Tag
{
    public string type { get; set; }
}

public class Accountid
{
    public string type { get; set; }
    public string format { get; set; }
}

public class Orderactivitycollection
{
    public string type { get; set; }
    public Items1 items { get; set; }
}

public class Items1
{
    public string type { get; set; }
    public string discriminator { get; set; }
    public Properties3 properties { get; set; }
}

public class Properties3
{
    public Activitytype activityType { get; set; }
}

public class Activitytype
{
    public string type { get; set; }
    public string[] _enum { get; set; }
}

public class Replacingordercollection
{
    public string type { get; set; }
}

public class Childorderstrategies
{
    public string type { get; set; }
}


}
