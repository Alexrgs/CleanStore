
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Cart.Queries.GetCartByUser
{
   public class GetCartQueryHandler : MediatR.IRequestHandler<GetCartQuery, CartViewModel>
    {
        private readonly IStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCartQueryHandler(IStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartViewModel> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _context
                .Carts.Include(i => i.Items).Where(p => p.UserId == request.UserId)
                .SingleOrDefaultAsync(cancellationToken);
            

            if (cart == null)
            {
                throw new NotFoundException(nameof(Cart), request.UserId);
            }

            return new CartViewModel() { Items = _mapper.Map<IEnumerable<CartItemModel>>(cart.Items) };
        }
    }

}
