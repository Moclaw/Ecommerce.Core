using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Core.Application.Features.Attributes.Queries.GetValuesById
{
    public class GetValuesByIdHandler
        (
         [FromKeyedServices(ServiceKeys.QueryRepository)]

            IQueryRepository<Domain.Entities.Attribute, int> repository
        )
        : IQueryHandler<GetValuesByIdRequest, GetValuesByIdResponse>
    {
        public async Task<Response<GetValuesByIdResponse>> Handle(
            GetValuesByIdRequest request, 
            CancellationToken cancellationToken
        )
        {
            var attribute = await repository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);
            
            if (attribute == null)
            {
                return new Response<GetValuesByIdResponse>(
                    IsSuccess: false, 
                    404, 
                    "Attribute not found", 
                    Data: null
                );
            }

            var response = new GetValuesByIdResponse
            {
                Id = attribute.Id,
                AttributeName = attribute.Name,
                // Map other properties as needed
            };
            
            return new Response<GetValuesByIdResponse>(
                IsSuccess: true, 
                200, 
                "Attribute values retrieved successfully", 
                Data: response
            );
        }
    }
}
