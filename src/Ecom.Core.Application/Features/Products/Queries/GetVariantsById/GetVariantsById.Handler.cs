using Ecom.Core.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Mapster;

namespace Ecom.Core.Application.Features.Products.Queries.GetVariantsById
{
    public class GetVariantsByIdHandler(
        [FromKeyedServices(ServiceKeys.QueryRepository)] IQueryRepository<Product, int> repository
    ) : IQueryCollectionHandler<GetVariantsByIdRequest, GetVariantsByIdResponse>
    {
        public async Task<ResponseCollection<GetVariantsByIdResponse>> Handle(
            GetVariantsByIdRequest request,
            CancellationToken cancellationToken
        )
        {
            var product = await repository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);
            
            if (product == null)
            {
                return new ResponseCollection<GetVariantsByIdResponse>(
                    IsSuccess: false,
                    404,
                    "Product not found",
                    Data: []
                );
            }

            var variants = product.Variants?.Adapt<List<GetVariantsByIdResponse>>() ?? [];

            return new ResponseCollection<GetVariantsByIdResponse>(
                IsSuccess: true,
                200,
                "Product variants retrieved successfully",
                Data: variants
            );
        }
    }
}
