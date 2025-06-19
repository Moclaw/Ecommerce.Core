using Ecom.Core.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Core.Application.Features.Categories.Queries.GetCatagoryById
{
    public class GetCatagoryByIdHandler(
        [FromKeyedServices(ServiceKeys.QueryRepository)] IQueryRepository<Category, int> repository
    ) : IQueryHandler<GetCatagoryByIdRequest, GetCatagoryByIdResponse>
    {
        public async Task<Response<GetCatagoryByIdResponse>> Handle(
            GetCatagoryByIdRequest request,
            CancellationToken cancellationToken
        )
        {
            // Implementation goes here

            return new Response<GetCatagoryByIdResponse>(
                IsSuccess: true,
                200,
                "",
                Data: new GetCatagoryByIdResponse()
            );
        }
    }
}
