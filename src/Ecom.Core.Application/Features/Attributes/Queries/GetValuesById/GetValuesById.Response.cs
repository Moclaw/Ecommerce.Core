namespace Ecom.Core.Application.Features.Attributes.Queries.GetValuesById
{
    public class GetValuesByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int AttributeId { get; set; }
        public string AttributeName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
