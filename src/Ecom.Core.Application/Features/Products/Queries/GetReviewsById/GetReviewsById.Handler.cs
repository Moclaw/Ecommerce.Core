using Ecom.Core.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Mapster;

namespace Ecom.Core.Application.Features.Products.Queries.GetReviewsById
{
    public class GetReviewsByIdHandler(
        [FromKeyedServices(ServiceKeys.QueryRepository)] IQueryRepository<Product, int> repository
    ) : IQueryCollectionHandler<GetReviewsByIdRequest, GetReviewsByIdResponse>
    {
        public async Task<ResponseCollection<GetReviewsByIdResponse>> Handle(
            GetReviewsByIdRequest request,
            CancellationToken cancellationToken
        )
        {
            var product = await repository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);
            
            if (product == null)
            {
                return new ResponseCollection<GetReviewsByIdResponse>(
                    IsSuccess: false,
                    404,
                    "Product not found",
                    Data: []
                );
            }

            var reviews = product.Reviews?.Adapt<List<GetReviewsByIdResponse>>() ?? [];

            return new ResponseCollection<GetReviewsByIdResponse>(
                IsSuccess: true,
                200,
                "Product reviews retrieved successfully",
                Data: reviews
            );
        }
    }
}
