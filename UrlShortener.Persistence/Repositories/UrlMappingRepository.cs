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
        public async Task<string> CreateAsync(string url,string shortCode)
        {
            var existUrl= await context.Urls.FirstOrDefaultAsync(x=>x.OriginUrl==url);
            if (existUrl != null)
            {
                return existUrl.ShortCode;
            }
            var newUrl = new UrlMapping()
            {
                OriginUrl = url,
                ShortCode = shortCode,
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
        public async Task<bool> ExistUrlAsync(string originalUrl)
        {
            return await context.Urls.AnyAsync(x => x.OriginUrl == originalUrl);

        }
        //private string GenerateShortCode()
        //{
        //    return Guid.NewGuid().ToString("N")[..6]; //6 simvol
        //}
    }
}
