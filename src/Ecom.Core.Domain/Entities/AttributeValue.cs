namespace Ecom.Core.Domain.Entities;

public class AttributeValue : BaseEntity, IEntity<int>
{
    public int Id { get; set; }

    public int AttributeId { get; set; }

    public string Value { get; set; } = null!;

    public Attribute Attribute { get; set; } = null!;
}