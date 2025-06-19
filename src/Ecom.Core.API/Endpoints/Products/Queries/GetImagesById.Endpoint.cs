using Ecom.Core.Application.Features.Products.Queries.GetImagesById;

namespace Ecom.Core.API.Endpoints.Products.Queries
{
    public class GetImagesByIdEndpoint(IMediator mediator)
        : CollectionEndpointBase<GetImagesByIdRequest, GetImagesByIdResponse>(mediator)
    {
        [HttpGet("products-images")]
        public override async Task<ResponseCollection<GetImagesByIdResponse>> HandleAsync(
            GetImagesByIdRequest req,
            CancellationToken ct
        )
        {
            return await _mediator.Send(req, ct);
        }
    }
}
