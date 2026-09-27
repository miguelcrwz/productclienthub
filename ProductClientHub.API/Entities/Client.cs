namespace ProductClientHub.API.Entities;

public class Client : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public List<Product> Products { get; set; } = [];
}
