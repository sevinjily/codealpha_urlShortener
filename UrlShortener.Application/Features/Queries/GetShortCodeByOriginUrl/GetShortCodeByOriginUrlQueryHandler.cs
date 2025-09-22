using MediatR;
using UrlShortener.Application.Interfaces.Repository;
using UrlShortener.Application.Wrappers.ServiceResponses;

namespace UrlShortener.Application.Features.Queries.GetShortCodeByOriginUrl
{
    public class GetShortCodeByOriginUrlQueryHandler : IRequestHandler<GetShortCodeByOriginUrlQuery, ServiceResponseWithData<string?>>
    {
        private readonly IUrlMappingRepository repo;

        public GetShortCodeByOriginUrlQueryHandler(IUrlMappingRepository repo)
        {
            this.repo = repo;
        }
        public async Task<ServiceResponseWithData<string?>> Handle(GetShortCodeByOriginUrlQuery request, CancellationToken cancellationToken)
        {
            var existOriginUrlCode = await repo.ExistOriginUrlAsync(request.OriginUrl);

            if (!existOriginUrlCode)
                return new ServiceResponseWithData<string?>(default, false, System.Net.HttpStatusCode.NotFound, "OriginUrl not found!");


            var findShortCode = await repo.GetShortCodeByOriginUrlAsync(request.OriginUrl);

            return new ServiceResponseWithData<string?>(findShortCode?.ShortCode, true, System.Net.HttpStatusCode.Found);
        }
    }
}
