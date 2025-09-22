using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Interfaces.Repository;
using UrlShortener.Domain.Entity;
using UrlShortener.Persistence.Context;

namespace UrlShortener.Persistence.Repositories
{
    public class UrlMappingRepository : IUrlMappingRepository
    {
        private readonly AppDbContext context;

        public UrlMappingRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<string> CreateAsync(string url)
        {
            var existUrl=context.Urls.FirstOrDefaultAsync(x=>x.OriginUrl==url);
            if (existUrl != null)
            {
                var newUrl = new UrlMapping()
                {
                    OriginUrl = url,
                    ShortCode = string.Empty,
                };
    
           await context.Urls.AddAsync(newUrl);
            await context.SaveChangesAsync();
            return newUrl.ShortCode;
            }

            return null;

        }

        public async Task<UrlMapping?> GetOriginUrlByShortCodeAsync(string shortCode)
        {

          var findUrl=  await context.Urls.FirstOrDefaultAsync(x=> x.ShortCode == shortCode);
            if(findUrl == null) return null;

            return findUrl;
        }

        public async Task<UrlMapping?> GetShortCodeByOriginUrlAsync(string originUrl)
        {
           var findUrl= await context.Urls.FirstOrDefaultAsync(x => x.OriginUrl == originUrl);
            if (findUrl == null) return null;

            return findUrl;
        }
        public  bool ExistUrl(string originalUrl)
        {
            var existUrl=context.Urls.FirstOrDefault(x=>x.OriginUrl == originalUrl);
            if (existUrl == null) return false;
             return true;

        }
        //private string GenerateShortCode()
        //{
        //    return Guid.NewGuid().ToString("N")[..6]; //6 simvol
        //}
    }
}
