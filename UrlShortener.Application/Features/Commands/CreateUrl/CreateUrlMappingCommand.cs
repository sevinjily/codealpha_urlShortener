using MediatR;
using UrlShortener.Application.Wrappers.ServiceResponses;

namespace UrlShortener.Application.Features.Commands.CreateUrl
{
    public class CreateUrlMappingCommand:IRequest<ServiceResponseWithData<string>>
    {
        public string OriginalUrl { get; set; }



    }
}
