using Store.Domain.Entities;
using Store.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Application.Tests.Infrastructure
{
    public class TestStoreDBInitializer
    {

        private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();
        private readonly Dictionary<int, CartItem> CartItems = new Dictionary<int, CartItem>();
        private readonly Dictionary<int, Domain.Entities.Cart> Carts = new Dictionary<int, Domain.Entities.Cart>();

        public static void Initialize(StoreDbContext context)
        {
            var initializer = new TestStoreDBInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(StoreDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return; // Db has been seeded
            }

            SeedProducts(context);
            SeedCarts(context);
            SeedCartItems(context);

        }

        private void SeedCartItems(StoreDbContext context)
        {
            CartItems.Add(1, new CartItem() { CartId = 1 , ProductId =1 , Quantity  =1 });
            CartItems.Add(2, new CartItem() { CartId = 1, ProductId = 2, Quantity = 2 });

            foreach (var item in CartItems.Values)
            {
                context.CartItems.Add(item);
            }

            context.SaveChanges();
        }

        private void SeedCarts(StoreDbContext context)
        {
            Carts.Add(1, new Domain.Entities.Cart() { UserId = "Alex@rgs.pw" });
            
            foreach (var cart in Carts.Values)
            {
                context.Carts.Add(cart);
            }

            context.SaveChanges();
        }

        private void SeedProducts(StoreDbContext context)
        {
            Products.Add(1, new Product() { ProductName = "KeyBoard", UnitPrice = 151.00m, UnitsInStock = 5, ProductDescription = "Test product description keyboard", ProductImgURL = "/mockimg/keyboard.jpg" });
            Products.Add(2, new Product() { ProductName = "Mouse", UnitPrice = 100.00m, UnitsInStock = 5, ProductDescription = "Test product description mouse", ProductImgURL = "/mockimg/mouse.jpg" });
            Products.Add(3, new Product() { ProductName = "laptop", UnitPrice = 1500.00m, UnitsInStock = 5, ProductDescription = "Test product description laptop", ProductImgURL = "/mockimg/laptop.jpg" });

            foreach (var product in Products.Values)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
