using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Net.Http;
using TD_API_Interface;
using Microsoft.Extensions.Configuration;
//using System.Configuration;
//using Microsoft.Extensions.Configuration.FileExtensions;
//using Microsoft.Extensions.Configuration.Json;
//using System.Reflection;

namespace WorkingMansDayTradingTests
{

    [TestClass]
    public class UnitTestSecretsAndHttpClient
    {
        [TestInitialize]
        public void Setup()
        {
            ///https://patrickhuber.github.io/2017/07/26/avoid-secrets-in-dot-net-core-tests.html
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<UnitTestSecretsAndHttpClient>();

            Configuration = builder.Build();
        }
        IConfiguration Configuration { get; set; }


        [TestMethod]
        public void TestCanGetSecreteRefreshToken()
        {
            string rToken = Configuration["refresh_token"];
            Assert.IsTrue((string.IsNullOrWhiteSpace(rToken) ? "someValue" : rToken) != "someValue");
            Assert.IsNotNull(Configuration["Consumer_Key"]);
        }
    }
}
