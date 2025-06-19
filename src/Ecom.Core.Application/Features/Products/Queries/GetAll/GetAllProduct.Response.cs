namespace Ecom.Core.Application.Features.Products.Queries.GetAll
{
    public class GetAllResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string>? Images { get; set; }

        public List<int>? Categories { get; set; }

    }
}