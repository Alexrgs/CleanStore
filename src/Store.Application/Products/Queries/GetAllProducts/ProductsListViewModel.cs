using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Products.Queries.GetAllProducts
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
