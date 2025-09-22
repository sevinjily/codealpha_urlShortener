using MediatR;
using UrlShortener.Application.Wrappers.ServiceResponses;

namespace UrlShortener.Application.Features.Queries.GetShortCodeByOriginUrl
{
    public class GetShortCodeByOriginUrlQuery:IRequest<ServiceResponseWithData<string?>>
    {
        public string OriginUrl { get; set; }
    }
}
