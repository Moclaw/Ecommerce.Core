using MinimalAPI.Attributes;

namespace Ecom.Core.Application.Features.Attributes.Queries.GetValuesById
{
    public class GetValuesByIdRequest : IQueryRequest<GetValuesByIdResponse>
    {
        [FromRoute]
        public int Id { get; set; }
    }
}
