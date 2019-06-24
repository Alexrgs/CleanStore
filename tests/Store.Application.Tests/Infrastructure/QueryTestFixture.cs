using AutoMapper;
using Store.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public StoreDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = DbContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
