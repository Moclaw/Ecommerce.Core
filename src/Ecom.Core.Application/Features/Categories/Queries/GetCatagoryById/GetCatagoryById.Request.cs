using MinimalAPI.Attributes;

namespace Ecom.Core.Application.Features.Categories.Queries.GetCatagoryById
{
    public class GetCatagoryByIdRequest : IQueryRequest<GetCatagoryByIdResponse>
    {
        [FromRoute]
        public int Id { get; set; }
    }
}
