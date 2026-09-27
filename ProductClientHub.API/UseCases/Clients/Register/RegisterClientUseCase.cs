using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exception.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register;
    public class RegisterProducttUseCase
    {
        public ResponseShortProduct Execute(RequestClientJson request)
        {

            Validate(request);
            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email
            };
            
            var dbContext = new ProductClientHubDbContext();
            dbContext.Clients.Add(entity);
            dbContext.SaveChanges();

        return new ResponseShortProduct
        {
            Id = entity.Id,
            Name = entity.Name
        };

        }

    private void Validate(RequestClientJson request)
    {
        var validator = new RegisterClientValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);

        }
    }

    }
