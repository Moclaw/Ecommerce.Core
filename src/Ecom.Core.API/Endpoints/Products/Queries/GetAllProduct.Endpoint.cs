using Ecom.Core.Application.Features.Products.Queries.GetAll;

namespace Ecom.Core.API.Endpoints.Products.Queries
{
    public class GetAllProductEnpoint(IMediator mediator)
        : CollectionEndpointBase<GetAllRequest, GetAllResponse>(mediator)
    {
        [HttpGet("products")]
        public override async Task<ResponseCollection<GetAllResponse>> HandleAsync(
            GetAllRequest req,
            CancellationToken ct
        )
        {
            return await _mediator.Send(req, ct);
        }
    }
}
