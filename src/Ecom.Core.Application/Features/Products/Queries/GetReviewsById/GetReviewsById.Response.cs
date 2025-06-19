namespace Ecom.Core.Application.Features.Products.Queries.GetReviewsById
{
    public class GetReviewsByIdResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public int Rating { get; set; }    // 1–5
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
