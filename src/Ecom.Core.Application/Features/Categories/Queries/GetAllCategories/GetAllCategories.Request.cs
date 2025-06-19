namespace Ecom.Core.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesRequest : IQueryCollectionRequest<GetAllCategoriesResponse>
    {
        public string? Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; } = "";
        public bool IsAscending { get; set; }
    }
}
