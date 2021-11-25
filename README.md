# AIStockTradingBot

**WARNING**: Using this software will probably lose you money. The owners and contributors will not be liable for any losses. 
The AIStockTradingBot will someday handle my Stock Trading Strategy while I am away.   
It's intention is to handle trades, save price data, and analyze based on algorithms.  Also providing actionable notifications.  
It's currently intended for software developers or aspiring software developers.  It requires the user to write code to build algorithms, pick stocks to trade, and set guidelines.

Currently this is all based on the TD Ameritrade API but the long term intention is to provide this service to multiple account providers.  As well as eventually search news and social media AI updates. 

##Contributors are Welcome and Desired##

I admit I hastefully ignored some best practice setting this up.  If contributors appear I will rangle these practices in, but for now I am focused to use this bot as fast as possible.  Until then I will continue to try and get desired personal value out of this software.

##Current Setup Requirements Unit Tests##

1.  Create TD Ameritrade Trading Account (ideally a Traditional or ROFL IRA Account -details below-)
2.	Register for Ameritrade developer API access: [The follow the guide](https://developer.tdameritrade.com/content/phase-1-authentication-update-xml-based-api)
	a.  Create your own app
	b.  Registar your app to your account
	c.  Get your refresh token 
3.  Setup your secrete.json file
	a.  refresh_token = Insert the refresh toke provided by TDA
	b.  Consumer_Key = Insert the APP/API Consumer Key provided by TDA
	c.	TradingDataPath = choose a path on your machine to store data
	d.	Account01 = Your TDA account number
```JSON
{
  "refresh_token": "",
  "Consumer_Key": "",
  "TradingDataPath": "",
  "Account01": "",
  "Polygon_Default_Key": ""
}
```

## IRA Account Recommendation##

Provided you are under the age of retirement I suggest creating a new IRA account if you intend to use the AITradingBot to execute orders.  I have done this myself (My Account details below).  My intent for the stock trading bot in not intended to purchase long term investments, that is easy enough to do without a bot.  Instead it's intended to do short term low profit trades, ideally smart enough to work around the SEC day trading rules.  Without hiding within an IRA every transaction would need to be evaluated during income tax time.  IRA transactions don't require tax preparation for each three cent transaction.

## New Direction

My original plan was to move faster and share my AI Stock Trading Bot core code.  Just would have allowed others to create their own trading logic and test it out.  

However reality was a much different then I once dreamed.  My theory that all the logic would stay here in the core project wasn't fully realized as I created console, service, web, and mobile applications.   

Learning more about cyber security was been a massive detour from this code base.  While the education gain is worth it's weight in gold, the time on that endeavor has taken away from my time expanding this core code base. 

I believe in more minds make better code.  This being my first open source project I was jaded enough think other like minded individuals would join in and help contribute to this project.  However that never happened on the software side of this project.  I am still open to others joining in an leading a hand, but at this point a ton of code lives outside of this project.  

As the paths to this dream project become clearer it's become apparent that changes are in store for the next year.  While the limited roots of this project will remain here telling the story of how I started.  The future landscape for the forseeable is to increase the the private codebase and reduce the publicly shared items.  

This **New Direction** was written on Thanksgiving day 2021.  Sometime between then and the first part on 2022 the logic and integration testing portion of this code will be moved to a private repository.  Before some major updates occur.  Which will basically leave the api wrappers to provide a stepping stone for other developers out there.

I am working on a new plan to share this project in different ways at some point in the future.