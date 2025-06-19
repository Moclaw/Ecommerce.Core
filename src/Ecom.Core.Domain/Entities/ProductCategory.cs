namespace Ecom.Core.Domain.Entities;

public class ProductCategory : IEntity<int>
{
    public int Id { get; set; }
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public Product Product { get; set; } = null!;

    public Category Category { get; set; } = null!;
}
