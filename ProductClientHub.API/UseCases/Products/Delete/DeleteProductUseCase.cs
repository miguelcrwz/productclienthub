using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exception.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Delete;

public class DeleteProductUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new ProductClientHubDbContext();

        var entity = dbContext.Products.FirstOrDefault(products => products.Id == id);

        if (entity == null)
            throw new NotFoundException("Product not found.");

        dbContext.Products.Remove(entity);
        dbContext.SaveChanges();

    }
}
