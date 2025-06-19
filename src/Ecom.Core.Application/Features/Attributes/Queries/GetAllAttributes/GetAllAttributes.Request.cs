namespace Ecom.Core.Application.Features.Attributes.Queries.GetAllAttributes
{
    public class GetAllAttributesRequest : IQueryCollectionRequest<GetAllAttributesResponse>
    {
        public string? Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; } = "";
        public bool IsAscending { get; set; }
    }
}
