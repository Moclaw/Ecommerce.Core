namespace Ecom.Core.Domain.Entities;

public class ProductImage : BaseEntity, IEntity<int>
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? AltText { get; set; }

    public int Position { get; set; } = 0;

    public Product Product { get; set; } = null!;
}