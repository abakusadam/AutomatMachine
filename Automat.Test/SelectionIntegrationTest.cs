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
    public class SelectionIntegrationTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public SelectionIntegrationTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Should_Return_Success_When_Correct_Request()
        {

                var parameter = new ProductSelection();
                parameter.Slot = 2;
                parameter.SugarLevel = 0;
                parameter.SelectedPieces = 1;
                

                var response = await _client.PostAsJsonAsync("Automat/ProductSelection", parameter);

                var apiResult = await response.Content.ReadAsAsync<ProductSelectionResult>();

                Assert.True(0 == apiResult.Code);
            
        }

        [Fact]
        public async Task Should_Return_Error_When_Null_Request()
        {

            var parameter = new ProductSelection();
     
            var response = await _client.PostAsJsonAsync("Automat/ProductSelection", parameter);

            var apiResult = await response.Content.ReadAsAsync<ProductSelectionResult>();

            Assert.True(1 == apiResult.Code);

        }


        [Fact]
        public async Task Should_Return_Error_When_There_Is_No_Product()
        {

            var parameter = new ProductSelection();
            parameter.Slot = 99;
            parameter.SugarLevel = 0;
            parameter.SelectedPieces = 100;

            var response = await _client.PostAsJsonAsync("Automat/ProductSelection", parameter);

            var apiResult = await response.Content.ReadAsAsync<ProductSelectionResult>();

            Assert.True(1 == apiResult.Code);

        }


        [Fact]
        public async Task Should_Return_Error_When_SelectedPieces_Bigger_Than_NumberOfProducts()
        {

            var parameter = new ProductSelection();
            parameter.Slot = 99;
            parameter.SugarLevel = 0;
            parameter.SelectedPieces = 100;


            var response = await _client.PostAsJsonAsync("Automat/ProductSelection", parameter);

            var apiResult = await response.Content.ReadAsAsync<ProductSelectionResult>();
            //Assert
            Assert.True(1 == apiResult.Code);
        }


    }
}
