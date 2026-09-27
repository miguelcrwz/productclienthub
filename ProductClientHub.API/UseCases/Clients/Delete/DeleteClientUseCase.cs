using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exception.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Delete;

public class DeleteClientUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new ProductClientHubDbContext();
        var entity = dbContext.Clients.FirstOrDefault(clients => clients.Id == id);

        if (entity == null)
            throw new NotFoundException("Client not found.");

        dbContext.Clients.Remove(entity);
        dbContext.SaveChanges();
    }
}
