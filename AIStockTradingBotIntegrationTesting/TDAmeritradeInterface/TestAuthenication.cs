using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD_API_Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WorkingMansDayTradingTests
{
    [TestClass]
    public class TestAuthenication
    {
        IConfiguration Configuration { get; set; }
        //https://stackoverflow.com/questions/27376133/c-httpclient-with-post-parameters
        // HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
        // Instantiating an HttpClient class for every request will exhaust the number of sockets available under heavy loads. 
        // This will result in SocketException errors.
        // https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.7.1
        HttpClient client = new HttpClient();

        [TestInitialize]
        public void Setup()
        {
            ///https://patrickhuber.github.io/2017/07/26/avoid-secrets-in-dot-net-core-tests.html
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<UnitTestSecretsAndHttpClient>();
            Configuration = builder.Build();
        }

        [TestCleanup]
        public void cleanup()
        {
            client.Dispose();
        }

        [TestMethod]
        public void TestRefreshingAnAuthorizationToken()
        {
            var message = TD_API_Interface.API_Calls.Authentication.refreshToken(client, Configuration["refresh_token"], Configuration["Consumer_Key"]);
            Assert.IsNotNull(message);
        }
    }
}
