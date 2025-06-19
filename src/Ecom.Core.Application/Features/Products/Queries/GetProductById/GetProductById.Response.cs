namespace Ecom.Core.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdResponse : Products.DTOs.ProductDto
    {
        public string? Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
