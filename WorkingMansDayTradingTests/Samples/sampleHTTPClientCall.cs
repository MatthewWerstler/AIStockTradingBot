using System;
using System.Net.Http;
using System.Threading.Tasks;
//using netstandard;
//using System.Collections.Generic;
//using System.Runtime.Serialization.Json;


namespace TD_API_Interface
{
    public static class sampleHTTPClientCall 
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        private static readonly HttpClient client = new HttpClient();

        public static async Task<HttpResponseMessage> testHTTPClientCall()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                //Console.WriteLine(responseBody);
                return response;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
