using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Orders.Commands.SubmitOrder
{
    public class SubmitOrderCommandValidator : AbstractValidator<SubmitOrderCommand>
    {
        public SubmitOrderCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
