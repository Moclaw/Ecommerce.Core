namespace Ecom.Core.Domain.Entities;

public class ProductVariant : BaseEntity, IEntity<int>
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Sku { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; } = 0;

    public Product Product { get; set; } = null!;
    public ICollection<VariantAttributeValue> VariantAttributeValues { get; set; } = [];
}