using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TD_API_Interface.API_Calls
{
    /// <summary>
    /// TD Ameritrade Authentication API call
    /// https://developer.tdameritrade.com/authentication/apis
    /// All private, non-commercial use apps are currently limited to 120 requests per minute on all APIs except for Accounts & Trading
    /// </summary>
    public static class Authentication
    {
        /// <summary>
        /// Refresh Token to receive a valid API token.
        /// Documentation for authentication at TD Ameritrade  https://developer.tdameritrade.com/authentication/apis/post/token-0
        /// </summary>
        /// <param name="refreshToken">Refresh Token string from the original authorization_code process</param>
        /// <param name="client_id">client id parameter is also know as your apps Consumer Key "Consumer_Key" in Secrets Matt's file</param>
        public static string refreshToken(HttpClient client, string refreshToken, string client_id)
        {
            /**************************************All Token Body Parameters*************************************
            Name            Description
            grant_type      (required)  The grant type of the oAuth scheme.Possible values are authorization_code, refresh_token
            refresh_token   Required if using refresh token grant
            access_type     Set to off line to receive a refresh token
            code            Required if trying to use authorization code grant
            client_id       (required) OAuth User ID of your application
            redirect_uri    Required if trying to use authorization code grant
            -----------------------------------------------------------------------------------------------------
            However, we only calling the refresh token, method as found the initial instructions below
            https://developer.tdameritrade.com/content/phase-1-authentication-update-xml-based-api
            <In order to use this you will need to follow the instructions on the link above and get you initial 
             API access token and refresh token.  Then you will need to store the refresh_token in the secrets.json>
            --------
            Refresh Parameter
            grant_type: refresh_token
            refresh_token: {REFRESH TOKEN}
            client_id: {Consumer Key}
            ****************************************************************************************************/
            //Variables
            string apiReferenceURL = "https://api.tdameritrade.com/v1/oauth2/token";
            var parameters = new Dictionary<string, string> { { "grant_type", "refresh_token" }, { "refresh_token", refreshToken }, { "client_id", client_id } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            //API Call
            var result = client.PostAsync(apiReferenceURL, encodedContent).Result;
            //result.EnsureSuccessStatusCode();
            var contents = result.Content.ReadAsStringAsync().Result;
            dynamic jsonContents = JObject.Parse(contents);
            /****************************************Resource Error Codes****************************************
            HTTP Code   Description
            400         An error message indicating the validation problem with the request.
            401         An error message indicating the caller must pass valid credentials in the request body.
            500         An error message indicating there was an unexpected server error.
            403         An error message indicating the caller doesn't have access to the account in the request.
            503         An error message indicating there is a temporary problem responding.
            ****************************************************************************************************/
            return jsonContents.access_token.ToString();

        }
    }
}
