using Store.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Tests.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly StoreDbContext _context;

        public CommandTestBase()
        {
            _context = DbContextFactory.Create();
        }

        public void Dispose()
        {
            DbContextFactory.Destroy(_context);
        }
    }
}
