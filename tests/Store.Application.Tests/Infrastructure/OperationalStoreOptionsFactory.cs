using IdentityServer4.EntityFramework.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Tests.Infrastructure
{
    public class OperationalStoreOptionsFactory : IOptionsFactory<OperationalStoreOptions>
    {
        public OperationalStoreOptions Create(string name)
        {
            return new OperationalStoreOptions();
        }
    }
}
