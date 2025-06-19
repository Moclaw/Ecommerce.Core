using Ecom.Core.Application.Features.Products.Queries.GetProductById;

namespace Ecom.Core.API.Endpoints.Products.Queries
{
    public class GetProductByIdEndpoint(IMediator mediator)
        : SingleEndpointBase<GetProductByIdRequest, GetProductByIdResponse>(mediator)
    {
        [HttpGet]
        public override async Task<Response<GetProductByIdResponse>> HandleAsync(
            GetProductByIdRequest req,
            CancellationToken ct
        )
        {
            return await _mediator.Send(req, ct);
        }
    }
}
