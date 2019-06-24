using MediatR;
using Moq;
using Shouldly;
using Store.Application.Cart.Commands.AdjustQuantity;
using Store.Application.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Store.Application.Tests.Cart.Commands
{
    public class AdjustQuantityCommandTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new AdjustQuantityCommand.Handler(_context, mediatorMock.Object);
            

            // Act
            var result = sut.Handle(new AdjustQuantityCommand { UserId = "Alex@rgs.pw", ProcuctId = 2 , Quantity = 3 }, CancellationToken.None);

            // Assert //TODO: Add more precise assert
            result.Status.ShouldBe(System.Threading.Tasks.TaskStatus.RanToCompletion);
        }
    }
}
