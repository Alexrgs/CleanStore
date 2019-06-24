using MediatR;
using Moq;
using Shouldly;
using Store.Application.Cart.Commands.AddProduct;
using Store.Application.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Store.Application.Tests.Cart.Commands
{
    public class AddProductCommandTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new AddProductCommand.Handler(_context, mediatorMock.Object);
           

            // Act
            var result = sut.Handle(new AddProductCommand { UserId = "Alex@rgs.pw" , ProcuctId = 3 }, CancellationToken.None);


            // Assert //TODO: Add more precise assert
            result.Status.ShouldBe(System.Threading.Tasks.TaskStatus.RanToCompletion);
            
        }


        [Fact]
        public async System.Threading.Tasks.Task Handle_AddExitingProductExceptionAsync()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new AddProductCommand.Handler(_context, mediatorMock.Object);

            // Act
            Exception ex = await Assert.ThrowsAsync<Exception>(() => sut.Handle(new AddProductCommand { UserId = "Alex@rgs.pw", ProcuctId = 2 }, CancellationToken.None));

            // Assert //TODO: Add more precise assert
            ex.Message.ShouldBe("Can't add duplicated products into the cart");           
        }

    }
}
