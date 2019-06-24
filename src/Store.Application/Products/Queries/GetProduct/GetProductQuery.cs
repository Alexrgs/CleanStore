using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }
}
