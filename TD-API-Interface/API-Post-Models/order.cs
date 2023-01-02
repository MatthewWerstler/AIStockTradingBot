using System;
using System.Collections.Generic;
using System.Text;

namespace TD_API_Interface.PostModels
{
    /// <summary>
    /// Mapping the JSON object to class which TDA expects to create order TDA samples Guide: https://developer.tdameritrade.com/content/place-order-samples
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

        private string Complexorderstrategytype;// = "NONE";
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

        public double? quantity { get; set; }
        public double? filledQuantity { get; set; }
        public double? remainingQuantity { get; set; }

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

        public double? stopPrice { get; set; }

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

        public double? stopPriceOffset { get; set; }

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

        public double? price { get; set; }

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
        
        public double? activationPrice { get; set; }

        private string Specialinstruction;// = "DO_NOT_REDUCE";
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
        public Int64? orderId { get; set; }

        public bool? cancelable { get; set; }// = true;

        public bool? editable { get; set; }// = true;

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

        public long? accountId { get; set; } = null;

        public List<Orderlegcollection> orderLegCollection { get; set; } 
        public Orderlegcollection orderActivityCollection { get; set; }
        public Orderlegcollection replacingOrderCollection { get; set; }
        public List<order> childOrderStrategies { get; set; }

        public string statusDescription { get; set; }

        public order()
        {
            orderLegCollection = new List<Orderlegcollection>();
            childOrderStrategies = null;
        }

        /// <summary>
        /// Simple buy/sell order for order creation
        /// </summary>
        /// <param name="isBuy">true = Buy & false = Sell</param>
        /// <param name="accountID">Account Number</param>
        /// <param name="Symbol">Stock Symbol Case Sensitive</param>
        /// <param name="quantity">int number of shares</param>
        /// <param name="limitBuyPrice">limit buy/sell price</param>
        public order(bool isBuy, string Symbol, int quantity, double limitBuyPrice) : this()
        {
            //simple stock order properties
            orderStrategyType = "SINGLE";
            price = limitBuyPrice;
            //order leg setup
            TD_API_Interface.PostModels.Orderlegcollection leg = new TD_API_Interface.PostModels.Orderlegcollection();
            if (isBuy)
                leg.instruction = "BUY";
            else
                leg.instruction = "SELL";
            leg.quantity = quantity;
            leg.instrument.symbol = Symbol;
            leg.instrument.assetType = "EQUITY";
            //attach order leg collection to this order
            orderLegCollection.Add(leg);
        }
        /// <summary>
        /// Create Standard Buy/Sell Conditional order
        /// </summary>
        public order(string symbol, int buyQuantity, double limitBuyPrice, int sellQuantity, double limitSellPrice, bool initialOrderDayOnly = true) : this()
        {
            //DateTime threeMonthsFromToday = DateTime.Now.AddMonths(3);
            orderType = "LIMIT";
            session = "Normal";
            if(initialOrderDayOnly)
            { 
                duration = "DAY";
            }
            else
            { 
                duration = "GOOD_TILL_CANCEL";
            }
            orderStrategyType = "TRIGGER";
            price = limitBuyPrice;
            //Buy order leg
            TD_API_Interface.PostModels.Orderlegcollection leg = new TD_API_Interface.PostModels.Orderlegcollection();
            leg.instruction = "BUY";
            leg.quantity = buyQuantity;
            leg.instrument.symbol = symbol;
            leg.instrument.assetType = "EQUITY"; //Needs to be different for ETFs
            //attach order leg collection to this order
            orderLegCollection.Add(leg);

            //Create the Triggered order
            order childOrderStrategy = new order();
            childOrderStrategy.orderType = "LIMIT";
            childOrderStrategy.session = "Normal";
            childOrderStrategy.duration = "GOOD_TILL_CANCEL";
            //childOrderStrategy.cancelTime = $"{threeMonthsFromToday.Year.ToString()}-{threeMonthsFromToday.Month.ToString()}-{threeMonthsFromToday.Day.ToString()}";
            childOrderStrategy.orderStrategyType = "SINGLE";
            childOrderStrategy.price = limitSellPrice;
            childOrderStrategy.Complexorderstrategytype = "NONE";
            //Sell order leg
            TD_API_Interface.PostModels.Orderlegcollection sellLeg = new TD_API_Interface.PostModels.Orderlegcollection();
            sellLeg.instruction = "SELL";
            sellLeg.quantity = sellQuantity;
            sellLeg.instrument.symbol = symbol;
            sellLeg.instrument.assetType = "EQUITY"; //Needs to be different for ETFs
            childOrderStrategy.orderLegCollection.Add(sellLeg);

            //Attach Child order
            childOrderStrategies = new List<order>();
            childOrderStrategies.Add(childOrderStrategy);
        }
    }


    public class Orderlegcollection
    {
        private string Instruction;
        /// <summary> instruction = "BUY", "SELL", "BUY_TO_COVER", "SELL_SHORT", "BUY_TO_OPEN", "BUY_TO_CLOSE", "SELL_TO_OPEN", "SELL_TO_CLOSE", or "EXCHANGE"</summary>
        public string instruction
        {
            get => Instruction;
            set
            {
                List<string> limitStrings = new List<string> { "BUY", "SELL", "BUY_TO_COVER", "SELL_SHORT",
                    "BUY_TO_OPEN", "BUY_TO_CLOSE", "SELL_TO_OPEN", "SELL_TO_CLOSE", "EXCHANGE" };
                if (limitStrings.Contains(value))
                    Instruction = value;
            }
        }

        private string OrderLegType;
        /// <summary>orderLegType = "EQUITY". "OPTION". "INDEX". "MUTUAL_FUND". "CASH_EQUIVALENT". "FIXED_INCOME". or "CURRENCY" </summary>
        public string orderLegType
        {
            get => OrderLegType;
            set
            {
                List<string> limitStrings = new List<string> { "EQUITY", "OPTION", "INDEX", "MUTUAL_FUND", 
                    "CASH_EQUIVALENT", "FIXED_INCOME", "CURRENCY" };
                if (limitStrings.Contains(value))
                    OrderLegType = value;
            }
        }

        public int? legId { get; set; } 

        private string Positioneffect;
        /// <summary>
        /// positionEffect = "OPENING", "CLOSING" or "AUTOMATIC"
        /// </summary>
        public string positionEffect
        {
            get => Positioneffect;
            set
            {
                List<string> limitStrings = new List<string> { "OPENING", "CLOSING", "AUTOMATIC" };
                if (limitStrings.Contains(value))
                    Positioneffect = value;
            }
        }
        public int quantity { get; set; }

        private string Quantitytype;
        /// <summary>quantityType = "ALL_SHARES", "DOLLARS" or "SHARES"</summary>
        public string quantityType
        {
            get => Quantitytype;
            set
            {
                List<string> limitStrings = new List<string> { "ALL_SHARES", "DOLLARS", "SHARES" };
                if (limitStrings.Contains(value))
                    Quantitytype = value;
            }
        }

        public Instrument instrument { get; set; }//"The type <Instrument> has the following subclasses [Option, MutualFund, CashEquivalent, Equity, FixedIncome] descriptions are listed below\"",
    
        public Orderlegcollection()
        {
            instrument = new Instrument();
        }
    }


    //---> TO DO Replace this with interfaces
    public class Instrument
    {
        public string assetType { get; set; } //'EQUITY' or 'OPTION' or 'INDEX' or 'MUTUAL_FUND' or 'CASH_EQUIVALENT' or 'FIXED_INCOME' or 'CURRENCY'",
        public string cusip { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }

    }
    
}
