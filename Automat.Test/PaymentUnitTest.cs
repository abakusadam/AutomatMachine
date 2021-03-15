using Automat.Application.Model;
using Automat.Application.Port;
using Automat.Test.Adapters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Automat.Test
{
    public class PaymentUnitTest
    {
        [Fact]
        public async Task Should_Return_Error_When_Null_Request_For_PaymentByCash()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());

            //Act
            var result = await automatFacade.PaymentByCash(null);

            //Assert
            Assert.Equal(1, result.Code);
        }

        [Fact]
        public async Task Should_Return_Error_When_CachAmount_Send_0_For_PaymentByCash()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());

            //Act
            PaymentByCashEntity paymentByCashEntity = new PaymentByCashEntity();
            paymentByCashEntity.CashAmount = 0;
            paymentByCashEntity.Id = 1;
            paymentByCashEntity.TransactionId = 1;

            var result = await automatFacade.PaymentByCash(paymentByCashEntity);

            //Assert
            Assert.Equal(1, result.Code);
        }

        [Fact]
        public async Task Should_Return_Error_When_TransactionAmount_Bigger_Than_CachAmount()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());

            //Act
            PaymentByCashEntity paymentByCashEntity = new PaymentByCashEntity();
            paymentByCashEntity.CashAmount = 1;
            paymentByCashEntity.Id = 1;
            paymentByCashEntity.TransactionId = 1;
            var result = await automatFacade.PaymentByCash(paymentByCashEntity);

            //Assert
            Assert.Equal(1, result.Code);
        }

        [Fact]
        public async Task Should_Return_Error_When_Null_Request_For_PaymentByCreditCard()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());

            //Act
            var result = await automatFacade.PaymentByCreditCard(null);

            //Assert
            Assert.Equal(1, result.Code);
        }

        [Fact]
        public async Task Should_Return_Error_When_Sending_Wrong_Card_Info_For_PaymentByCreditCard()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());

            //Act
            PaymentByCreditCardEntity paymentByCreditCardEntity = new PaymentByCreditCardEntity();
            paymentByCreditCardEntity.Pan = "";
            paymentByCreditCardEntity.Year = 2020;
            paymentByCreditCardEntity.Month = 12;
            var result = await automatFacade.PaymentByCreditCard(paymentByCreditCardEntity);

            //Assert
            Assert.Equal(1, result.Code);

        }
    }
}
