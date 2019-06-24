using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ProductsListViewModel>
    {
        public string DescriptionContains { get; set; }
    }
}
