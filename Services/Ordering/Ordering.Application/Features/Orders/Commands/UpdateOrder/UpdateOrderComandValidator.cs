using System;
using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
	public class UpdateOrderComandValidator : AbstractValidator<UpdateOrderCommand>
	{
		public UpdateOrderComandValidator()
		{
            RuleFor(p => p.UserName)
                .NotEmpty()
                .WithMessage("{UserName} is requeired")
                .NotNull()
                .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters");

            RuleFor(p => p.EmailAddress)
                .NotEmpty().WithMessage("{EmailAddress} is required");

            RuleFor(p => p.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
        }
	}
}

