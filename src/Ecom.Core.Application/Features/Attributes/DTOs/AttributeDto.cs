namespace Ecom.Core.Application.Features.Attributes.DTOs
{
    public record AttributeDto
    {
        public int AttributeId { get; set; }
        public string? AttributeName { get; set; }
        public int ValueId { get; set; }
        public string? Value { get; set; }
    }
}
