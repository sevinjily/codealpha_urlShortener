using UrlShortener.Domain.Entity;

namespace UrlShortener.Application.Interfaces.Repository
{
    public interface IUrlMappingRepository
    {
        Task<string> CreateAsync(string url,string shortCode);
        Task<UrlMapping?> GetOriginUrlByShortCodeAsync(string shortCode);
        Task<UrlMapping?> GetShortCodeByOriginUrlAsync(string originUrl);
        Task<bool> ExistUrlAsync(string url);
    }
}
