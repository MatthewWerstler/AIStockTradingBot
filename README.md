# AIStockTradingBot

WARNING: Using this software will probably lose you money. The owners and contributors will not be liable for any losses. 
The AIStockTradingBot will someday handle my Stock Trading Strategy while I am away.   
It's intention is to handle trades, save price data, and analyze based on algorithms.  Also providing actionable notifications.  
It's currently intended for software developers or aspiring software developers.  It requires the user to write code to build algorithms, pick stocks to trade, and set guidelines.

Currently this is all based on the TD Ameritrade API but the long term intention is to provide this service to multiple account providers.  As well as eventually search news and social media AI updates. 

--Contributors are Welcome and Desired--
I admit I hastefully ignored some best practice setting this up.  If contributors appear I will rangle these practices in, but for now I am excited to use this bot as fast as possible.  Until then I will continue to try and get desired personal value out of this software.

--Current Setup Requirements--
1.  Create TD Ameritrade Trading Account (ideally a Traditional or ROFL IRA Account -details below-)
2.	Register for Ameritrade developer API access: The follow the guide (https://developer.tdameritrade.com/content/phase-1-authentication-update-xml-based-api)
	a.  Create your own app
	b.  Registar your app to your account
	c.  Get your refresh token 
3.  Setup your secrete.json file
	a.  refresh_token = Insert the refresh toke provided by TDA
	b.  Consumer_Key = Insert the APP/API Consumer Key provided by TDA
	c.	TradingDataPath = choose a path on your machine to store data
	d.	Account01 = Your TDA account number
-----------------------------------------------------------------------------------------------
{
  "refresh_token": "",
  "Consumer_Key": "",
  "TradingDataPath": "",
  "Account01": ""
}
-----------------------------------------------------------------------------------------------

--IRA Account recommendation 
Provided you are under the age of retirement I suggest creating a new IRA account if you intend to use the AITradingBot to excute orders.  I have done this myself (My Account details below).  My intent for the stock trading bot in not intended to purchase long term investments, that is easy enough to do without a bot.  Instead it's intended to do short term low profit trades, ideally smart enough to work around the SEC day trading rules.  Without hiding within an IRA every transaction would need to be evaluated during income tax time.  IRA transactions don't require tax preparation for each three cent transaction.

--My Account--
My account is a new ROFL that only has $25 in it, and I am contributing $5 additional dollars per paycheck.  This process if completely experimental AI trading bots have consistantly failed to beat the market.  Those bots were created by stock brokers and data scientists.  I am neither: Anyone using this bot should understand they are gambling here and expect the bot will lose all money it has access to.  Yet I still dare to dream that there could be something here, and hope other software developers will join me and contribute to that dream.