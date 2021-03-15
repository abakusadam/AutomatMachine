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
    public class PaymentByCashIntegrationTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public PaymentByCashIntegrationTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Should_Return_Success_When_Send_Correct_Request_For_PaymentByCash()
        {
            var parameter = new ProductSelection();
            parameter.Slot = 2;
            parameter.SugarLevel = 0;
            parameter.SelectedPieces = 1;

            var responseProductSelection = await _client.PostAsJsonAsync("Automat/ProductSelection", parameter);
            var apiProductSelectionResult = await responseProductSelection.Content.ReadAsAsync<ProductSelectionResult>();

            PaymentByCashEntity paymentByCashEntity = new PaymentByCashEntity();
            paymentByCashEntity.TransactionId = apiProductSelectionResult.TransactionId;
            paymentByCashEntity.CashAmount = apiProductSelectionResult.TotalAmount;

            var response = await _client.PostAsJsonAsync("Automat/PaymentByCash", paymentByCashEntity);
            var apiResult = await response.Content.ReadAsAsync<TransactionResult>();

            Assert.True(0 == apiResult.Code);
        }

        [Fact]
        public async Task Should_Return_Error_When_Send_Zero_CashAmount_Request_For_PaymentByCash()
        {
            var parameter = new ProductSelection();
            parameter.Slot = 2;
            parameter.SugarLevel = 0;
            parameter.SelectedPieces = 1;

            var responseProductSelection = await _client.PostAsJsonAsync("Automat/ProductSelection", parameter);
            var apiProductSelectionResult = await responseProductSelection.Content.ReadAsAsync<ProductSelectionResult>();

            PaymentByCashEntity paymentByCashEntity = new PaymentByCashEntity();
            paymentByCashEntity.TransactionId = apiProductSelectionResult.TransactionId;
            paymentByCashEntity.CashAmount = 0;

            var response = await _client.PostAsJsonAsync("Automat/PaymentByCash", paymentByCashEntity);
            var apiResult = await response.Content.ReadAsAsync<TransactionResult>();

            Assert.True(1 == apiResult.Code);
            Assert.Equal("Lütfen para giriniz!", apiResult.Message);
        }

        [Fact]
        public async Task Should_Return_Error_When_Send_Non_Transaction_Id_Request_For_PaymentByCash()
        {
            PaymentByCashEntity paymentByCashEntity = new PaymentByCashEntity();
            paymentByCashEntity.TransactionId = -1;
            paymentByCashEntity.CashAmount = 1;

            var response = await _client.PostAsJsonAsync("Automat/PaymentByCash", paymentByCashEntity);
            var apiResult = await response.Content.ReadAsAsync<TransactionResult>();

            Assert.True(1 == apiResult.Code);
            Assert.Equal($"TransactionId: {paymentByCashEntity.TransactionId} Message: TransactionId değeri bulunamadı!", apiResult.Message);
        }

        [Fact]
        public async Task Should_Return_Error_When_Send_NonCorrect_CashAmount_Request_For_PaymentByCash()
        {
            var parameter = new ProductSelection();
            parameter.Slot = 2;
            parameter.SugarLevel = 0;
            parameter.SelectedPieces = 1;

            var responseProductSelection = await _client.PostAsJsonAsync("Automat/ProductSelection", parameter);
            var apiProductSelectionResult = await responseProductSelection.Content.ReadAsAsync<ProductSelectionResult>();

            PaymentByCashEntity paymentByCashEntity = new PaymentByCashEntity();
            paymentByCashEntity.TransactionId = apiProductSelectionResult.TransactionId;
            paymentByCashEntity.CashAmount = 1;

            var response = await _client.PostAsJsonAsync("Automat/PaymentByCash", paymentByCashEntity);
            var apiResult = await response.Content.ReadAsAsync<TransactionResult>();

            Assert.True(1 == apiResult.Code);
            Assert.Equal("Lütfen yeterli para giriniz!", apiResult.Message);
        }

        [Fact]
        public async Task Should_Return_Error_When_Send_Paid_Transaction_Id_Request_For_PaymentByCash()
        {
            PaymentByCashEntity paymentByCashEntity = new PaymentByCashEntity();
            paymentByCashEntity.TransactionId = 1;
            paymentByCashEntity.CashAmount = 1;

            var response = await _client.PostAsJsonAsync("Automat/PaymentByCash", paymentByCashEntity);
            var apiResult = await response.Content.ReadAsAsync<TransactionResult>();

            Assert.True(1 == apiResult.Code);
            Assert.Equal($"Bu işlem Gerçekleşmiştir! Transaction id {paymentByCashEntity.TransactionId}", apiResult.Message);
        }
    }
}
