using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductsListViewModel>
    {
        private readonly IStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsListViewModel> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IList<Product> products;

            if (!string.IsNullOrEmpty(request.DescriptionContains))
            {
                products = await _context.Products.Where(w => w.ProductDescription.Contains(request.DescriptionContains)).ToListAsync(cancellationToken);
            }else
            {
                products = await _context.Products.ToListAsync(cancellationToken);
            }

            var model = new ProductsListViewModel
            {
                Products = _mapper.Map<IEnumerable<ProductDto>>(products)                
            };

            return model;
        }
    }
}
