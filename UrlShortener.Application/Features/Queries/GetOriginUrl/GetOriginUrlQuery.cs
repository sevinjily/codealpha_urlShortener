using MediatR;
using UrlShortener.Application.Wrappers.ServiceResponses;
using UrlShortener.Domain.Entity;

namespace UrlShortener.Application.Features.Queries.GetOriginUrl
{
    public class GetOriginUrlQuery:IRequest<ServiceResponseWithData<string?>>
    {
        public string ShortCode { get; set; }
    }
}
