using Shouldly;
using Store.Application.Products.Queries.GetAllProducts;
using Store.Application.Tests.Infrastructure;
using Store.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using AutoMapper;

namespace Store.Application.Tests.Products.Queries
{   
    [Collection("QueryCollection")]
    public class GetAllProductsQueryHandlerTests
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAllWithDescriptionMatching()
        {
            var sut = new GetAllProductsQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetAllProductsQuery { DescriptionContains = "laptop" }, CancellationToken.None);

            result.ShouldBeOfType<ProductsListViewModel>();
            result.Products.Count().ShouldBe(1);
        }

        [Fact]
        public async Task GetAll()
        {
            var sut = new GetAllProductsQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetAllProductsQuery() , CancellationToken.None);

            result.ShouldBeOfType<ProductsListViewModel>();
            result.Products.Count().ShouldBe(3);
        }
    }
}
