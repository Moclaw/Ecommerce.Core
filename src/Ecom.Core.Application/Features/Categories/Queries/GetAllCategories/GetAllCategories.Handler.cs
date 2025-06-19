using Ecom.Core.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Shared.Utils;

namespace Ecom.Core.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler(
        [FromKeyedServices(ServiceKeys.QueryRepository)] IQueryRepository<Category, int> repository
    ) : IQueryCollectionHandler<GetAllCategoriesRequest, GetAllCategoriesResponse>
    {
        public async Task<ResponseCollection<GetAllCategoriesResponse>> Handle(
            GetAllCategoriesRequest request, 
            CancellationToken cancellationToken
        )
        {
            var categories = await repository.GetAllAsync<GetAllCategoriesResponse>(
                paging: new Pagination(default, request.PageIndex, request.PageSize),
                cancellationToken: cancellationToken
            );

            return new ResponseCollection<GetAllCategoriesResponse>(
                true,
                200,
                "Categories retrieved successfully.",
                [.. categories.Entities]
            );
        }
    }
}
