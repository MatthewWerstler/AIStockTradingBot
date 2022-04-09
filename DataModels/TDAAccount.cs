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

}
