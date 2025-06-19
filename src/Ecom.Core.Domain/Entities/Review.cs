namespace Ecom.Core.Domain.Entities;

public class Review : BaseEntity, IEntity<int>
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int? UserId { get; set; }

    public int Rating { get; set; }

    public string? Title { get; set; }

    public string? Comment { get; set; }

    public Product Product { get; set; } = null!;
}