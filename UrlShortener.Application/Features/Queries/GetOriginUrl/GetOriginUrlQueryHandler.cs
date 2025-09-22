using MediatR;
using UrlShortener.Application.Interfaces.Repository;
using UrlShortener.Application.Wrappers.ServiceResponses;
using UrlShortener.Domain.Entity;

namespace UrlShortener.Application.Features.Queries.GetOriginUrl.GetOriginUrl
{
    public class GetOriginUrlQueryHandler : IRequestHandler<GetOriginUrlQuery, ServiceResponseWithData<string?>>
    {
        private readonly IUrlMappingRepository repo;

        public GetOriginUrlQueryHandler(IUrlMappingRepository repo)
        {
            this.repo = repo;
        }
        public async Task<ServiceResponseWithData<string?>> Handle(GetOriginUrlQuery request, CancellationToken cancellationToken)
        {
             var existShortCode = await repo.ExistShortCodeAsync(request.ShortCode);

            if (!existShortCode)
                return new ServiceResponseWithData<string?>(default, false, System.Net.HttpStatusCode.NotFound, "ShortCode not found!");


            var findOriginUrl=await repo.GetOriginUrlByShortCodeAsync(request.ShortCode);

            return new ServiceResponseWithData<string?>(findOriginUrl.OriginUrl, true, System.Net.HttpStatusCode.Found);
        }
    }
}
