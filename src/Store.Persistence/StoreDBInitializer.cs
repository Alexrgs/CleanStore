using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Persistence
{
    public class StoreDBInitializer
    {
    
        private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();

        public static void Initialize(StoreDbContext context)
        {
            var initializer = new StoreDBInitializer();
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
        }

        private void SeedProducts(StoreDbContext context)
        {
            Products.Add(1,new Product() { ProductName = "KeyBoard", UnitPrice = 150.00m, UnitsInStock = 5, ProductDescription = "Test product description keyboard", ProductImgURL = "/mockimg/keyboard.jpg"  });
            Products.Add(2, new Product() { ProductName = "Mouse", UnitPrice = 150.00m, UnitsInStock = 5, ProductDescription = "Test product description mouse", ProductImgURL = "/mockimg/mouse.jpg" });
            Products.Add(3, new Product() { ProductName = "laptop", UnitPrice = 150.00m, UnitsInStock = 5, ProductDescription = "Test product description laptop", ProductImgURL = "/mockimg/laptop.jpg" });

            foreach (var product in Products.Values)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
