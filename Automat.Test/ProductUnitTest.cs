using Automat.Application.Port;
using Automat.Test.Adapters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Automat.Test
{
    public class ProductUnitTest
    {
        [Fact]
        public async Task Should_Return_Success_When_Request_To_ProductGetAll()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());

            //Act
            var result = await automatFacade.ProductGetAll();

            //Assert
            Assert.Equal(1, result.Count);
        }


        [Fact]
        public async Task Should_Return_Success_When_Request_To_CampaingGetAll()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());

            //Act
            var result = await automatFacade.CampaingGetAll();

            //Assert
            Assert.Equal(1, result.Count);
        }
    }
}
