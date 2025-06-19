namespace Ecom.Core.Domain.Entities;


public class Product : BaseEntity, IEntity<int>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal? SalePrice { get; set; }

    public string? SeoTitle { get; set; }

    public string? SeoDescription { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; set; } = [];

    public ICollection<ProductVariant> Variants { get; set; } = [];

    public ICollection<ProductImage> Images { get; set; } = [];

    public ICollection<Review> Reviews { get; set; } = [];
}