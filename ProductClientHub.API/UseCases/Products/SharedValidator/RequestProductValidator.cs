using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Products.SharedValidator;

public class RequestProductValidator : AbstractValidator<RequestProductJson>
{
    public RequestProductValidator() 
    { 
        RuleFor(product => product.Name)
            .NotEmpty()
            .WithMessage("The name field is required.")
            .MaximumLength(100)
            .WithMessage("The name field must not exceed 100 characters.");

        RuleFor(product => product.Brand)
            .NotEmpty()
            .WithMessage("The brand field is required.")
            .MaximumLength(50)
            .WithMessage("The brand field must not exceed 50 characters.");

        RuleFor(product => product.Price)
            .GreaterThan(0)
            .WithMessage("The price field must be greater than zero.");
    }
}
