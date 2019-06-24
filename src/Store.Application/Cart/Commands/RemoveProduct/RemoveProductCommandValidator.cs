using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Cart.Commands.RemoveProduct
{
    public class RemoveProductCommandValidator : AbstractValidator<RemoveProductCommand>
    {
        public RemoveProductCommandValidator()
        {
            RuleFor(x => x.ProcuctId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
   
}
