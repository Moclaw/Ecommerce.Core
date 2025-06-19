using Ecom.Core.Application.Features.Products.Queries.GetReviewsById;

namespace Ecom.Core.API.Endpoints.Products.Queries
{
    public class GetReviewsByIdEndpoint(IMediator mediator)
        : CollectionEndpointBase<GetReviewsByIdRequest, GetReviewsByIdResponse>(mediator)
    {
        [HttpGet("products-reviews")]
        public override async Task<ResponseCollection<GetReviewsByIdResponse>> HandleAsync(
            GetReviewsByIdRequest req,
            CancellationToken ct
        )
        {
            return await _mediator.Send(req, ct);
        }
    }
}
