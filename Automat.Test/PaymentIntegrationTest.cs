using Automat.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Automat.Test
{
    public class PaymentIntegrationTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public PaymentIntegrationTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }




    }
}
