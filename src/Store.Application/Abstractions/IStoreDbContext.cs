using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Abstractions
{
    public interface IStoreDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Domain.Entities.Cart> Carts { get; set; }
        DbSet<CartItem> CartItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
