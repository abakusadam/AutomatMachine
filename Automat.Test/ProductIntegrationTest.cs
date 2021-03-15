using Automat.API;
using Automat.Application.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Automat.Test
{
    public class ProductIntegrationTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ProductIntegrationTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }


        [Fact]
        public async Task Should_Return_Success_When_Request_To_ProductGetAll()
        {
            var response = await _client.GetAsync("Automat/GetProducts");

            var apiResult = await response.Content.ReadAsAsync<List<ProductEntity>>();

            //Assert
            Assert.True(apiResult.Count > 0);
        }


        [Fact]
        public async Task Should_Return_Success_When_Request_To_CampaingGetAll()
        {
            var response = await _client.GetAsync("Automat/GetCampaings");

            var apiResult = await response.Content.ReadAsAsync<List<CampaingEntity>>();

            //Assert
            Assert.True( apiResult.Count == 0);
        }

    }
}
