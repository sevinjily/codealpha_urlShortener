using UrlShortener.Domain.Entity;

namespace UrlShortener.Application.Interfaces.Repository
{
    public interface IUrlMappingRepository
    {
        Task<string> CreateAsync(string url);
        Task<UrlMapping?> GetOriginUrlByShortCodeAsync(string shortCode);
        Task<UrlMapping?> GetShortCodeByOriginUrlAsync(string originUrl);
        bool ExistUrl(string url);
    }
}
