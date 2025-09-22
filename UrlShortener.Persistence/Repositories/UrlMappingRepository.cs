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
        public async Task<string> CreateAsync(UrlMapping url)
        {
            var existUrl= await context.Urls.FirstOrDefaultAsync(x=>x.OriginUrl==url.OriginUrl);
            if (existUrl != null)
            {
                return existUrl.ShortCode;
            }
            var newUrl = new UrlMapping()
            {
                OriginUrl = url.OriginUrl,
                ShortCode = url.ShortCode,
            };

            await context.Urls.AddAsync(newUrl);
            await context.SaveChangesAsync();
            return newUrl.ShortCode;
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
        public async Task<bool> ExistOriginUrlAsync(string originalUrl)
        {
            return await context.Urls.AnyAsync(x => x.OriginUrl == originalUrl);

        }
        public async Task<bool> ExistShortCodeAsync(string shortCode)
        {
            return await context.Urls.AnyAsync(x => x.ShortCode == shortCode);

        }
      
    }
}
