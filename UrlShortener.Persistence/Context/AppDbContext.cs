using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entity;

namespace UrlShortener.Persistence.Context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UrlMapping> Urls { get; set; }
    }
}
