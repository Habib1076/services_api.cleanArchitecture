using Microsoft.EntityFrameworkCore;
using services_api.Infrastructure.Data;
using System;

namespace services_api.Infrastructure.Extensions
{
    public static class InfrastructureConfigurations
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration config) {

            services.AddDbContext<AppdbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("connection")));

            //services.AddDbContext<AppdbContext>(options =>
            //    options.UseInMemoryDatabase("MyDb"));


            services.AddOfferRepository();
            return services;
        }
    }
}
