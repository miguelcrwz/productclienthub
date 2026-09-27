using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Clients.SharedValidator;

public class RegisterClientValidator : AbstractValidator<RequestClientJson>
{
    public RegisterClientValidator()
    {
        RuleFor(client => client.Name) .NotEmpty().WithMessage("Client name is required.");
        RuleFor(client => client.Email).EmailAddress().WithMessage("A valid email address is required.");
    }
}
