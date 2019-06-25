
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

            // TODO: investigate why works on test and not in the real thing
            //var cart = await _context
            //    .Carts.Where(p => p.UserId == request.UserId)
            //    .Include(i => i.Items)
            //    .ThenInclude(cartItem => cartItem.Product) //  Works on tests on sqlite but not on MSSQL 
            //    .FirstOrDefaultAsync(cancellationToken);

            //Workaround use CartItems
            var cart = await _context.Carts.SingleOrDefaultAsync(w => w.UserId == request.UserId, cancellationToken);
            var cartItems = await _context.CartItems
                .Where(p => p.Cart.UserId == request.UserId)
                .Include(i => i.Product)
                .ToListAsync(cancellationToken);

            if (cart == null)
            {
                _context.Carts.Add(new Domain.Entities.Cart() {  UserId = request.UserId });
                 var result =  await _context.SaveChangesAsync(cancellationToken);
                cartItems = await _context.CartItems.Where(w => w.Cart.CartId == result).ToListAsync(cancellationToken);
            }

            return new CartViewModel() { Items = _mapper.Map<IEnumerable<CartItemModel>>(cartItems) };
        }
    }

}
