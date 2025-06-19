using MinimalAPI.Attributes;

namespace Ecom.Core.Application.Features.Products.Queries.GetImagesById
{
    public class GetImagesByIdRequest : IQueryCollectionRequest<GetImagesByIdResponse>
    {
        [FromRoute]
        public int Id { get; set; }
        public string? Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; } = "";
        public bool IsAscending { get; set; }
    }
}
