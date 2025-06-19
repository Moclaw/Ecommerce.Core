namespace Ecom.Core.Domain.Entities;

public class Category : BaseEntity, IEntity<int>
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int? ParentId { get; set; }

    public Category? Parent { get; set; }

    public ICollection<Category> Children { get; set; } = [];

    public ICollection<ProductCategory> ProductCategories { get; set; } = [];
}