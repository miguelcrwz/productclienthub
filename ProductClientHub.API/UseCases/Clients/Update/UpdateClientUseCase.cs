using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exception.ExceptionsBase;
using System.Linq.Expressions;

namespace ProductClientHub.API.UseCases.Clients.Update;

public class UpdateClientUseCase
{
    public void Execute(Guid clientId, RequestClientJson request)
    {
        Validate(request);
        var dbContext = new ProductClientHubDbContext();
        var entity = dbContext.Clients.FirstOrDefault(client => client.Id == clientId);

        if(entity is null)
            throw new NotFoundException("Client not found");

        entity.Name = request.Name;
        entity.Email = request.Email;

        dbContext.Clients.Update(entity);
        dbContext.SaveChanges();
    }

    private void Validate(RequestClientJson request)
    {
        var validator = new RegisterClientValidator();
        var results = validator.Validate(request);

        if (results.IsValid == false)
        {
            var errors = results.Errors.Select(failure => failure.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}
