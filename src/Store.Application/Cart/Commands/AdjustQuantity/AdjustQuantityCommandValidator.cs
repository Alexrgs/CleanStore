using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Cart.Commands.AdjustQuantity
{
    class AdjustQuantityCommandValidator : AbstractValidator<AdjustQuantityCommand>
    {
        public AdjustQuantityCommandValidator()
        {
            RuleFor(x => x.ProcuctId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo((short)1).NotEmpty();
        }
    }
}

    

