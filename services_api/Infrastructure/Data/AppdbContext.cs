using Microsoft.EntityFrameworkCore;
using services_api.Domain.Entities;

namespace services_api.Infrastructure.Data
{
    public class AppdbContext : DbContext
    {
        
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options) { }
        public DbSet<Offer> Offers { get; set; }
        //public DbSet<Section> Sections { get; set; }

    }
}
