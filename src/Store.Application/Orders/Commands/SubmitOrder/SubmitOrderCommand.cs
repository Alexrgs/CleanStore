using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Application.Exceptions;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Orders.Commands.SubmitOrder
{
    public class SubmitOrderCommand : IRequest
    {
        public string UserId { get; set; }

        public class Handler : IRequestHandler<SubmitOrderCommand, Unit>
        {
            private readonly IStoreDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IStoreDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(SubmitOrderCommand request, CancellationToken cancellationToken)
            {
                var UserCart = await _context.Carts.Include(i=> i.Items).SingleOrDefaultAsync(w => w.UserId == request.UserId, cancellationToken);

                //Verify if user have a cart
                if (UserCart == null)
                {
                    throw new NotFoundException(nameof(Domain.Entities.Cart), request.UserId);
                }

                //A user must not be able to submit an order for an empty cart.
                if (UserCart.Items.Count == 0)
                {
                    throw new Exception("Can't submit order because the cart is empty");
                }

                //TODO: Add submit order logic here 

                //clean user cart 
                UserCart.Items = new List<CartItem>();

                _context.Carts.Update(UserCart);
               await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

