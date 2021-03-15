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
    public class PaymentByCreditCardIntegrationTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public PaymentByCreditCardIntegrationTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Should_Return_Success_When_Send_Correct_Request_For_PaymentByCreditCard()
        {
            var parameter = new ProductSelection();
            parameter.Slot = 3;
            parameter.SugarLevel = 0;
            parameter.SelectedPieces = 1;

            var responseProductSelection = await _client.PostAsJsonAsync("Automat/ProductSelection", parameter);
            var apiProductSelectionResult = await responseProductSelection.Content.ReadAsAsync<ProductSelectionResult>();

            PaymentByCreditCardEntity paymentByCreditCardEntity = new PaymentByCreditCardEntity();
            paymentByCreditCardEntity.TransactionId = apiProductSelectionResult.TransactionId;
            paymentByCreditCardEntity.Pan = "4355084355084358";
            paymentByCreditCardEntity.Month = 12;
            paymentByCreditCardEntity.Year = 21;
            paymentByCreditCardEntity.Cvc = "000";

            var response = await _client.PostAsJsonAsync("Automat/PaymentByCreditCard", paymentByCreditCardEntity);
            var apiResult = await response.Content.ReadAsAsync<TransactionResult>();

            Assert.True(0 == apiResult.Code);
        }

        [Fact]
        public async Task Should_Return_Error_When_NonCorrect_Pan_Request_For_PaymentByCreditCard()
        {
            var parameter = new ProductSelection();
            parameter.Slot = 3;
            parameter.SugarLevel = 0;
            parameter.SelectedPieces = 1;

            var responseProductSelection = await _client.PostAsJsonAsync("Automat/ProductSelection", parameter);
            var apiProductSelectionResult = await responseProductSelection.Content.ReadAsAsync<ProductSelectionResult>();

            PaymentByCreditCardEntity paymentByCreditCardEntity = new PaymentByCreditCardEntity();
            paymentByCreditCardEntity.TransactionId = apiProductSelectionResult.TransactionId;
            paymentByCreditCardEntity.Pan = "";
            paymentByCreditCardEntity.Month = 12;
            paymentByCreditCardEntity.Year = 21;
            paymentByCreditCardEntity.Cvc = "000";

            var response = await _client.PostAsJsonAsync("Automat/PaymentByCreditCard", paymentByCreditCardEntity);
            var apiResult = await response.Content.ReadAsAsync<TransactionResult>();

            Assert.True(1 == apiResult.Code);
            Assert.Equal($"CardInfo: {apiResult.TransactionId} Message: Kredi kartı bilgileri bulunamadı!", apiResult.Message);
        }

        [Fact]
        public async Task Should_Return_Error_When_Send_Non_Transaction_Id_Request_For_PaymentByCreditCard()
        {
            PaymentByCreditCardEntity paymentByCreditCardEntity = new PaymentByCreditCardEntity();
            paymentByCreditCardEntity.TransactionId = -1;
            paymentByCreditCardEntity.Pan = "4355084355084358";
            paymentByCreditCardEntity.Month = 12;
            paymentByCreditCardEntity.Year = 21;
            paymentByCreditCardEntity.Cvc = "000";

            var response = await _client.PostAsJsonAsync("Automat/PaymentByCreditCard", paymentByCreditCardEntity);
            var apiResult = await response.Content.ReadAsAsync<TransactionResult>();

            Assert.True(1 == apiResult.Code);
            Assert.Equal($"TransactionId: {paymentByCreditCardEntity.TransactionId} Message: TransactionId değeri bulunamadı!", apiResult.Message);
        }

        [Fact]
        public async Task Should_Return_Error_When_Sending_Paid_Transaction_Id_Request_For_PaymentByCreditCard()
        {
            PaymentByCreditCardEntity paymentByCreditCardEntity = new PaymentByCreditCardEntity();
            paymentByCreditCardEntity.TransactionId = 1;
            paymentByCreditCardEntity.Pan = "4355084355084358";
            paymentByCreditCardEntity.Month = 12;
            paymentByCreditCardEntity.Year = 21;
            paymentByCreditCardEntity.Cvc = "000";

            var response = await _client.PostAsJsonAsync("Automat/PaymentByCreditCard", paymentByCreditCardEntity);
            var apiResult = await response.Content.ReadAsAsync<TransactionResult>();

            Assert.True(1 == apiResult.Code);
            Assert.Equal($"Bu işlem Gerçekleşmiştir! Transaction id {paymentByCreditCardEntity.TransactionId}", apiResult.Message);
        }
    }
}
