using UrlShortener.Domain.Entity;

namespace UrlShortener.Application.Interfaces.Repository
{
    public interface IUrlMappingRepository
    {
        Task<string> CreateAsync(UrlMapping url);
        Task<UrlMapping?> GetOriginUrlByShortCodeAsync(string shortCode);
        Task<UrlMapping?> GetShortCodeByOriginUrlAsync(string originUrl);
        Task<bool> ExistOriginUrlAsync(string url);
        Task<bool> ExistShortCodeAsync(string shortCode);
    }
}
