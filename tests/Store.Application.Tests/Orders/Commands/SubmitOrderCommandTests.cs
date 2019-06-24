using MediatR;
using Moq;
using Store.Application.Orders.Commands.SubmitOrder;
using Store.Application.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Store.Application.Tests.Orders.Commands
{
    public class SubmitOrderCommandTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new SubmitOrderCommand.Handler(_context, mediatorMock.Object);
            var newCustomerId = "QAZQ1";

            // Act
            var result = sut.Handle(new SubmitOrderCommand { UserId = "alex@gmail.com" }, CancellationToken.None);


            // Assert
           
        }
    }
}
