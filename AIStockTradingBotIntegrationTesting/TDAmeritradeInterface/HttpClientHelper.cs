using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace WorkingMansDayTradingTests.TDAmeritradeInterface
{
    public class HttpClientHelper : IDisposable
    {
        public HttpClient client;
        private IConfiguration Configuration { get; set; }
        private string _apiKey;
        public string apiKey { get { return _apiKey; } }
        private string _account01;
        public string account01 { get { return _account01; } }
        private string _path;
        public string path { get { return _path; } }

        public HttpClientHelper()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<UnitTestSecretsAndHttpClient>();
            Configuration = builder.Build();
            client = new HttpClient();
            _apiKey = Configuration["Consumer_Key"];
            _account01 = Configuration["Account01"];
            _path = Configuration["TradingDataPath"];
            string Authorization = TD_API_Interface.API_Calls.Authentication.refreshToken(client, Configuration["refresh_token"], apiKey);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authorization);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                client.Dispose();
                Configuration = null;
                _apiKey = null;
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
