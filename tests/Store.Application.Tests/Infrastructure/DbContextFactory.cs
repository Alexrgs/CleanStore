using IdentityServer4.EntityFramework.Options;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Store.Application.Abstractions;
using Store.Domain;
using Store.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Tests.Infrastructure
{
    public class DbContextFactory
    { 
        public static StoreDbContext Create()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<StoreDbContext>()
               // .UseInMemoryDatabase(Guid.NewGuid().ToString()) //Throws null reference exception when data doesn't exist,when it should return null  
               .UseSqlite(connection)
                .Options;

            var operationalStoreOption = new OptionsManager<OperationalStoreOptions>( new OperationalStoreOptionsFactory());

            var context = new StoreDbContext(options, operationalStoreOption);

            context.Database.EnsureCreated();

            TestStoreDBInitializer.Initialize(context);

            return context;
        }

        public static void Destroy(StoreDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
