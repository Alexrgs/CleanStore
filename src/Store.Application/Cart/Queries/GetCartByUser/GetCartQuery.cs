using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Cart.Queries.GetCartByUser
{
    public class GetCartQuery : IRequest<CartViewModel>
    {
        public string UserId { get; set; }
    }

}

