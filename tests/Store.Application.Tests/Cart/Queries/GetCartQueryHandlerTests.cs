using AutoMapper;
using Shouldly;
using Store.Application.Cart.Queries.GetCartByUser;
using Store.Application.Exceptions;
using Store.Application.Tests.Infrastructure;
using Store.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Store.Application.Tests.Cart.Queries
{    
    [Collection("QueryCollection")]
    public class GetCartQueryHandlerTests
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCartQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Get()
        {
            var sut = new GetCartQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCartQuery { UserId = "Alex@rgs.pw" }, CancellationToken.None);

            result.ShouldBeOfType<CartViewModel>();
            result.Items.Count().ShouldBe(2);
            result.Total.ShouldBe(351.0m);
        }

    }
}
