namespace Ecom.Core.Domain.Entities;


public class VariantAttributeValue : BaseEntity, IEntity<int>
{
    public int Id { get; set; }

    public int VariantId { get; set; }

    public int AttributeValueId { get; set; }

    public ProductVariant Variant { get; set; } = null!;

    public AttributeValue AttributeValue { get; set; } = null!;
}