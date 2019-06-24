using IdentityServer4.Configuration;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Store.Persistence.Infrastructure
{
    //public abstract class DesignTimeDbContextFactoryBase<TContext> :
    //   IDesignTimeDbContextFactory<TContext> where TContext : ApiAuthorizationDbContext<ApplicationUser>
    //{
    //    private const string ConnectionStringName = "StoreDatabase";
    //    private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

    //    public TContext CreateDbContext(string[] args)
    //    {
    //        var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}Store.WebUI", Path.DirectorySeparatorChar);
    //        return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
    //    }

    //    protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions);

    //    private TContext Create(string basePath, string environmentName)
    //    {

    //        var configuration = new ConfigurationBuilder()
    //            .SetBasePath(basePath)
    //            .AddJsonFile("appsettings.json")
    //            .AddJsonFile($"appsettings.Local.json", optional: true)
    //            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
    //            .AddEnvironmentVariables()
    //            .Build();

    //        var connectionString = configuration.GetConnectionString(ConnectionStringName);

    //        return Create(connectionString , configuration);
    //    }

        

    //    private TContext Create(string connectionString, IConfigurationRoot configuration)
    //    {
    //        if (string.IsNullOrEmpty(connectionString))
    //        {
    //            throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
    //        }

    //        Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

    //        var optionsBuilder = new DbContextOptionsBuilder<TContext>();

    //        optionsBuilder.UseSqlServer(connectionString);
           
           
    //        return CreateNewInstance(optionsBuilder.Options ,null );
    //    }
    //}
}
