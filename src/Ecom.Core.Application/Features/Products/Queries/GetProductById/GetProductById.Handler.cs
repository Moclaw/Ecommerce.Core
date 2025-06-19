using Ecom.Core.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Mapster;

namespace Ecom.Core.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandler(
        [FromKeyedServices(ServiceKeys.QueryRepository)] IQueryRepository<Product, int> repository
    ) : IQueryHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        public async Task<Response<GetProductByIdResponse>> Handle(
            GetProductByIdRequest request,
            CancellationToken cancellationToken
        )
        {
            var product = await repository.GetByIdAsync<GetProductByIdResponse>(
                request.Id, 
                cancellationToken: cancellationToken
            );

            if (product == null)
            {
                return new Response<GetProductByIdResponse>(
                    IsSuccess: false,
                    404,
                    "Product not found",
                    Data: null
                );
            }

            return new Response<GetProductByIdResponse>(
                IsSuccess: true,
                200,
                "Product retrieved successfully",
                Data: product
            );
        }
    }
}
