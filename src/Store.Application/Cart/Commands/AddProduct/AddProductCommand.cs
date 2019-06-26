using MediatR;
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

namespace Store.Application.Cart.Commands.AddProduct
{


    public class AddProductCommand : IRequest
    {
        public string UserId { get; set; }
        public int ProcuctId { get; set; }

        public class Handler : IRequestHandler<AddProductCommand, Unit>
        {
            private readonly IStoreDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IStoreDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
            {
                var procuct = await _context.Products.SingleOrDefaultAsync(w => w.ProductId == request.ProcuctId, cancellationToken);

                //Validate if it's real product
                if (procuct == null)
                {
                    throw new NotFoundException(nameof(Product), request.ProcuctId);
                }

                var UserCart = await _context.Carts.Include(i=> i.Items).SingleOrDefaultAsync(w => w.UserId == request.UserId, cancellationToken);
                
                //Verify if user have a cart
                if (UserCart == null)
                {
                    throw new NotFoundException(nameof(Domain.Entities.Cart), request.UserId);
                }

                //A user must not be able to add duplicate products into their cart
                if (UserCart.Items.Any(w => w.ProductId == request.ProcuctId))
                {
                    throw new Exception("Can't add duplicated products into the cart");
                }

                _context.CartItems.Add(new CartItem()
                {
                    Cart = UserCart,
                    ProductId = procuct.ProductId,
                    Quantity = 1,
                });

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
