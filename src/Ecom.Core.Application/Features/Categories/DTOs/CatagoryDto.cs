namespace Ecom.Core.Application.Features.Categories.DTOs
{
    public record CatagoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public int? ParentId { get; set; }
        public List<CatagoryDto>? Children { get; set; }
    }
}
