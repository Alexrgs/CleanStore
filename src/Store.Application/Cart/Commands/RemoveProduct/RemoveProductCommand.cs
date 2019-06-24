using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Cart.Commands.RemoveProduct
{
    public  class RemoveProductCommand : IRequest
    {
        public string UserId { get; set; }
        public int ProcuctId { get; set; }
        public class Handler : IRequestHandler<RemoveProductCommand, Unit>
        {
            private readonly IStoreDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IStoreDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
            {
                var UserCartItem = await _context.CartItems.FirstAsync(w =>
                w.ProductId == request.ProcuctId
                && w.Cart.UserId == request.UserId
                , cancellationToken);

                if (UserCartItem == null)
                {
                    throw new NotFoundException(nameof(Domain.Entities.CartItem), request.ProcuctId);
                }

                _context.CartItems.Remove(UserCartItem);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
