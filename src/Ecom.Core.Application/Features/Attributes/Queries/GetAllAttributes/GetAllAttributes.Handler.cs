using Microsoft.Extensions.DependencyInjection;
using Shared.Utils;

namespace Ecom.Core.Application.Features.Attributes.Queries.GetAllAttributes
{
    public class GetAllAttributesHandler(
        [FromKeyedServices(ServiceKeys.QueryRepository)]
            IQueryRepository<Domain.Entities.Attribute, int> repository
    ) : IQueryCollectionHandler<GetAllAttributesRequest, GetAllAttributesResponse>
    {
        public async Task<ResponseCollection<GetAllAttributesResponse>> Handle(
            GetAllAttributesRequest request,
            CancellationToken cancellationToken
        )
        {
            var attributes = await repository.GetAllAsync<GetAllAttributesResponse>(
                paging: new Pagination(default, request.PageIndex, request.PageSize),
                cancellationToken: cancellationToken
            );

            return new ResponseCollection<GetAllAttributesResponse>(
                IsSuccess: true, 
                200, 
                "Attributes retrieved successfully.",
                Data: [.. attributes.Entities]
            );
        }
    }
}
