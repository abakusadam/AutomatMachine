using Automat.Application.Model;
using Automat.Application.Port;
using Automat.Application.Port.Outgoing;
using Automat.Infrastructure.Adapter;
using Automat.Test.Adapters;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Automat.Test
{
    public class SelectionUnitTest
    {
        [Fact]
        public async Task Should_Return_Error_When_Null_Request()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());

            //Act
            var result =  await automatFacade.Selection(null);

            //Assert
            Assert.Equal(1, result.Code);
           
        }


        [Fact]
        public async Task Should_Return_Error_When_There_Is_No_Product()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());
            var moq = new Mock<FakeProductRepository>();
            moq.Setup(r => r.GetByIdAsync()).Returns(Task.FromResult<ProductEntity>(null));
            //Act

            ProductSelection productSelection = new ProductSelection();
            productSelection.Slot = 99;
            productSelection.SugarLevel = 0;
            productSelection.SelectedPieces = 100;
            var result = await automatFacade.Selection(productSelection);

            //Assert
            Assert.Equal(1, result.Code);

        }



        [Fact]
        public async Task Should_Return_Error_When_SelectedPieces_Bigger_Than_NumberOfProducts()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());
       
            //Act
            ProductSelection productSelection = new ProductSelection();
            productSelection.Slot = 99;
            productSelection.SugarLevel = 0;
            productSelection.SelectedPieces = 100;
            var result = await automatFacade.Selection(productSelection);

            //Assert
            Assert.Equal(1, result.Code);
        }

        [Fact]
        public async Task Should_Return_Success_When_There_Is_A_Campaing()
        {
            //Arrange
            var automatFacade = new AutomatFacade(new FakeProductRepository(), new FakeCampaingRepository(), new FakeTransactionRepository());

            //Act
            ProductSelection productSelection = new ProductSelection();
            productSelection.Slot = 1;
            productSelection.SugarLevel = 0;
            productSelection.SelectedPieces = 1;
            var result = await automatFacade.Selection(productSelection);

            //Assert
            Assert.Equal(0, result.Code);
            Assert.Equal((decimal)4.950, result.TotalAmount);
        }

    }
}
