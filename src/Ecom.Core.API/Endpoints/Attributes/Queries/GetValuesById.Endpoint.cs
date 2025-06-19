using Ecom.Core.Application.Features.Attributes.Queries.GetValuesById;

namespace Ecom.Core.API.Endpoints.Attributes.Queries
{
    public class GetValuesByIdEndpoint(IMediator mediator)
        : SingleEndpointBase<GetValuesByIdRequest, GetValuesByIdResponse>(mediator)
    {
        [HttpGet("attributes/values/{id}")]
        public override async Task<Response<GetValuesByIdResponse>> HandleAsync(
            GetValuesByIdRequest req,
            CancellationToken ct
        )
        {
            return await _mediator.Send(req, ct);
        }
    }
}
