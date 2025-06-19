namespace Ecom.Core.Application.Features.Products.Queries.GetImagesById
{
    public class GetImagesByIdResponse
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? AltText { get; set; }
        public int Position { get; set; }
    }
}
