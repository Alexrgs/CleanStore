using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Application.Exceptions;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : MediatR.IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly IStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context
                .Products.FirstOrDefaultAsync(p => p.ProductId == request.Id,
               cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            var view = _mapper.Map<ProductViewModel>(product);

            // TODO: Set view model state based on user permissions.
            view.EditEnabled = false;
            view.DeleteEnabled = false;

            return view;
        }
    }
}
