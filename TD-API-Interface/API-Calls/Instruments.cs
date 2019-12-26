using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TD_API_Interface.API_Calls
{
    /// <summary> Handles TD Ameritrade Instruments Calls https://developer.tdameritrade.com/instruments/apis</summary>
    public static class Instruments
    {


        /// <summary>
        /// GET - Search Instruments - Search or retrieve instrument data, including fundamental data.  https://developer.tdameritrade.com/instruments/apis/get/instruments
        /// 
        /// </summary>
        /// <param name="Authorization">Supply an access token to make an authenticated request. The format is Bearer <access token>.</param>
        /// <param name="apiKey">Pass your OAuth User ID to make an unauthenticated request for delayed data.</param>
        /// <param name="symbol">Value to pass to the search. See projection description for more information.</param>
        /// <param name="projection">'The type of request:
        ///         symbol-search: Retrieve instrument data of a specific symbol or cusip
        ///         symbol-regex: Retrieve instrument data for all symbols matching regex.Example: symbol= XYZ.* will return all symbols beginning with XYZ
        ///         desc-search: Retrieve instrument data for instruments whose description contains the word supplied.Example: symbol= FakeCompany will return all instruments with FakeCompany in the description.
        ///         desc-regex: Search description with full regex support. Example: symbol= XYZ.[A - C] returns all instruments whose descriptions contain a word beginning with XYZ followed by a character A through C.
        ///         fundamental: Returns fundamental data for a single instrument specified by exact symbol.'</param>
        /// <returns>HttpResponseMessage</returns>
        public static HttpResponseMessage getSearchInstrument(HttpClient client, string apiKey, string symbol, string projection)
        {
            string resourceURL = "https://api.tdameritrade.com/v1/instruments";
            string getFinalURL = $"{resourceURL}?apiKey={apiKey}&symbol={symbol}&projection={projection}";
            return client.GetAsync(getFinalURL).Result;

            /*********************Resource Error Codes**********************/
            //HTTP Code - Description
            //400   -   An error message indicating the caller must pass a non null value in the parameter.
            //401   -   Unauthorized
            //403   -   Forbidden
            //404   -   An error message indicating the instrument for the symbol/ cusip was not found.\
            //406   -   An error message indicating an issue in the symbol regex, or number of symbols searched is over the maximum.
            /*********************Ends Resource Error Codes**********************/
        }

        //GET - Get Instrument - Get an instrument by CUSIP https://developer.tdameritrade.com/instruments/apis/get/instruments/%7Bcusip%7D
        public static HttpResponseMessage getIntrument(HttpClient client, string apiKey, string cusip)
        {
            string url = $"https://api.tdameritrade.com/v1/instruments/{cusip}?apiKey={apiKey}";
            return client.GetAsync(url).Result;
        }
    }
}
