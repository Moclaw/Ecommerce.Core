using Ecom.Core.Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Shared.Utils;

namespace Ecom.Core.Application.Features.Products.Queries.GetAll
{
    public class GetAllHandler(
        [FromKeyedServices(ServiceKeys.QueryRepository)]
            IQueryRepository<Product, int> productRepository
    ) : IQueryCollectionHandler<GetAllRequest, GetAllResponse>
    {
        public async Task<ResponseCollection<GetAllResponse>> Handle(
            GetAllRequest request,
            CancellationToken cancellationToken
        )
        {
            var products = await productRepository.GetAllAsync<GetAllResponse>(
                paging: new Pagination(default, request.PageIndex, request.PageSize),
                cancellationToken: cancellationToken
            );

            return new ResponseCollection<GetAllResponse>(
                true,
                200,
                "Products retrieved successfully.",
                [.. products.Entities]
            );
        }
    }
}
