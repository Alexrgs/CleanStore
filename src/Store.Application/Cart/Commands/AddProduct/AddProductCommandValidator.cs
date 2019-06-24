using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Cart.Commands.AddProduct
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.ProcuctId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

}
