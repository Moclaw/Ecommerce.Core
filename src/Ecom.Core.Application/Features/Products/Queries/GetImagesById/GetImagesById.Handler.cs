using Ecom.Core.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Mapster;

namespace Ecom.Core.Application.Features.Products.Queries.GetImagesById
{
    public class GetImagesByIdHandler(
        [FromKeyedServices(ServiceKeys.QueryRepository)] IQueryRepository<Product, int> repository
    ) : IQueryCollectionHandler<GetImagesByIdRequest, GetImagesByIdResponse>
    {
        public async Task<ResponseCollection<GetImagesByIdResponse>> Handle(
            GetImagesByIdRequest request,
            CancellationToken cancellationToken
        )
        {
            var product = await repository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);
            
            if (product == null)
            {
                return new ResponseCollection<GetImagesByIdResponse>(
                    IsSuccess: false,
                    404,
                    "Product not found",
                    Data: []
                );
            }

            var images = product.Images?.Adapt<List<GetImagesByIdResponse>>() ?? [];

            return new ResponseCollection<GetImagesByIdResponse>(
                IsSuccess: true,
                200,
                "Product images retrieved successfully",
                Data: images
            );
        }
    }
}
