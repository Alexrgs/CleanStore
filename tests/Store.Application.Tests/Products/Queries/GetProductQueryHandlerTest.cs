using AutoMapper;
using Shouldly;
using Store.Application.Exceptions;
using Store.Application.Products.Queries.GetProduct;
using Store.Application.Tests.Infrastructure;
using Store.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Store.Application.Tests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetProductQueryHandlerTest
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Get()
        {
            var sut = new GetProductQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetProductQuery {  Id = 1}, CancellationToken.None);

            result.ShouldBeOfType<ProductViewModel>();
            result.ProductId.ShouldBe(1);
            result.ProductName.ShouldBe("KeyBoard");
        }

        [Fact]
        
        public async Task GetFail()
        {
            var sut = new GetProductQueryHandler(_context, _mapper);

            Exception ex = await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(new GetProductQuery { Id = 10 }, CancellationToken.None));

            ex.Message.ShouldBe("Entity \"Product\" (10) was not found.");
        }

    }
}
