using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{

    public class TDAAccount
    {
        public Securitiesaccount securitiesAccount { get; set; }
    }

    public class Securitiesaccount
    {
        public string type { get; set; }
        public string accountId { get; set; }
        public int roundTrips { get; set; }
        public bool isDayTrader { get; set; }
        public bool isClosingOnlyRestricted { get; set; }
        public Initialbalances initialBalances { get; set; }
        public Currentbalances currentBalances { get; set; }
        public Projectedbalances projectedBalances { get; set; }
        public List<OrderStrategies> orderStrategies { get; set; }
        public List<Positions> prositions { get; set; }
    }

    public class Initialbalances
    {
        public float accruedInterest { get; set; }
        public float availableFundsNonMarginableTrade { get; set; }
        public float bondValue { get; set; }
        public float buyingPower { get; set; }
        public float cashBalance { get; set; }
        public float cashAvailableForTrading { get; set; }
        public float cashReceipts { get; set; }
        public float dayTradingBuyingPower { get; set; }
        public float dayTradingBuyingPowerCall { get; set; }
        public float dayTradingEquityCall { get; set; }
        public float equity { get; set; }
        public float equityPercentage { get; set; }
        public float liquidationValue { get; set; }
        public float longMarginValue { get; set; }
        public float longOptionMarketValue { get; set; }
        public float longStockValue { get; set; }
        public float maintenanceCall { get; set; }
        public float maintenanceRequirement { get; set; }
        public float margin { get; set; }
        public float marginEquity { get; set; }
        public float moneyMarketFund { get; set; }
        public float mutualFundValue { get; set; }
        public float regTCall { get; set; }
        public float shortMarginValue { get; set; }
        public float shortOptionMarketValue { get; set; }
        public float shortStockValue { get; set; }
        public float totalCash { get; set; }
        public bool isInCall { get; set; }
        public float pendingDeposits { get; set; }
        public float marginBalance { get; set; }
        public float shortBalance { get; set; }
        public float accountValue { get; set; }
    }

    public class Currentbalances
    {
        public float accruedInterest { get; set; }
        public float cashBalance { get; set; }
        public float cashReceipts { get; set; }
        public float longOptionMarketValue { get; set; }
        public float liquidationValue { get; set; }
        public float longMarketValue { get; set; }
        public float moneyMarketFund { get; set; }
        public float savings { get; set; }
        public float shortMarketValue { get; set; }
        public float pendingDeposits { get; set; }
        public float availableFunds { get; set; }
        public float availableFundsNonMarginableTrade { get; set; }
        public float buyingPower { get; set; }
        public float buyingPowerNonMarginableTrade { get; set; }
        public float dayTradingBuyingPower { get; set; }
        public float equity { get; set; }
        public float equityPercentage { get; set; }
        public float longMarginValue { get; set; }
        public float maintenanceCall { get; set; }
        public float maintenanceRequirement { get; set; }
        public float marginBalance { get; set; }
        public float regTCall { get; set; }
        public float shortBalance { get; set; }
        public float shortMarginValue { get; set; }
        public float shortOptionMarketValue { get; set; }
        public float sma { get; set; }
        public float mutualFundValue { get; set; }
        public float bondValue { get; set; }
    }

    public class Projectedbalances
    {
        public float availableFunds { get; set; }
        public float availableFundsNonMarginableTrade { get; set; }
        public float buyingPower { get; set; }
        public float dayTradingBuyingPower { get; set; }
        public float dayTradingBuyingPowerCall { get; set; }
        public float maintenanceCall { get; set; }
        public float regTCall { get; set; }
        public bool isInCall { get; set; }
        public float stockBuyingPower { get; set; }
    }

    public class Positions
    {
        public float shortQuantity { get; set; }
        public float averagePrice { get; set; }
        public float currentDayCost { get; set; }
        public float currentDayProfitLoss { get; set; }
        public float currentDayProfitLossPercentage { get; set; }
        public float longQuantity { get; set; }
        public float settledLongQuantity { get; set; }
        public float settledShortQuantity { get; set; }
        public Instrument instrument { get; set; }
    }
    
    public class Instrument
    {
        public string assetType { get; set; }
        public string cusip { get; set; }
        public string symbol { get; set; }
        //public string description { get; set; }
    }

    public class OrderLegCollection
    {
        public string orderLegType { get; set; }
        public int legId { get; set; }
        public Instrument instrument { get; set; }
        public string instruction { get; set; }
        public string positionEffect { get; set; }
        public float quantity { get; set; }
    }

    public class OrderStrategies
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
        public List<OrderLegCollection> orderLegCollection { get; set; }
        public string orderStrategyType { get; set; }
        public string orderId { get; set; }
        public bool cancelable { get; set; }
        public bool editable { get; set; }
        public string status { get; set; }
        public string enteredTime { get; set; }
        public string tag { get; set; }
        public string accountId { get; set; }
        public List<OrderStrategies> childOrderStrategies { get; set; }
        public List<OrderActivity> orderActivityCollection { get; set; }

    }

    public class OrderActivity
    { 
        public string activityType { get; set; }
        public long activityId { get; set; }
        public string executionType { get; set; }
        public float quantity { get; set; }
        public float orderRemainingQuantity { get; set; }
        public List<ExecutionLeg> executionLegs { get; set; }
    }

    public class ExecutionLeg
    { 
        public int legId { get; set; }
        public float quantity { get; set; }
        public float mismarkedQuantity { get; set; }
        public float price { get; set; }
        public DateTime time { get; set; }
    }
}