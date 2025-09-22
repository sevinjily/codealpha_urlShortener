using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Application.Interfaces.Repository;
using UrlShortener.Persistence.Context;
using UrlShortener.Persistence.Repositories;

namespace UrlShortener.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUrlMappingRepository,UrlMappingRepository>();
        }
    }
}
