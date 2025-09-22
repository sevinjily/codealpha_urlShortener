using MediatR;
using UrlShortener.Application.Interfaces.Repository;
using UrlShortener.Application.Wrappers.ServiceResponses;
using UrlShortener.Domain.Entity;

namespace UrlShortener.Application.Features.Commands.CreateUrl
{
    public class CreateUrlMappingCommandHandler : IRequestHandler<CreateUrlMappingCommand, ServiceResponseWithData<string>>
    {
        private readonly IUrlMappingRepository repo;

        public CreateUrlMappingCommandHandler(IUrlMappingRepository repo)
        {
            this.repo = repo;
        }
        public async Task<ServiceResponseWithData<string>> Handle(CreateUrlMappingCommand request, CancellationToken cancellationToken)
        {
             var existUrl=await repo.ExistOriginUrlAsync(request.OriginalUrl);
            if (existUrl)
                return new ServiceResponseWithData<string>(default, false, System.Net.HttpStatusCode.BadRequest,"This url is already exist!");

            if(!string.IsNullOrEmpty(request.OriginalUrl) && request.OriginalUrl.EndsWith("/"))
            {
                request.OriginalUrl = request.OriginalUrl.TrimEnd('/');
            }
            var shortCode = GenerateShortCode();
            var newUrl = new UrlMapping()
            {
                OriginUrl = request.OriginalUrl,
                ShortCode = shortCode,

            };

            await repo.CreateAsync(newUrl);
            return new ServiceResponseWithData<string>(newUrl.ShortCode, true, System.Net.HttpStatusCode.Created,"Url created successfully!");
        }
        private string GenerateShortCode()
        {
            return Guid.NewGuid().ToString("N")[..6]; //6 simvol
        }
    }
}
