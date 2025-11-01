using services_api.Application.Extensions;
using services_api.Domain.Repositories;
using services_api.Infrastructure.Repositories;

namespace services_api.Infrastructure.Extensions
{
    public static class OfferRepositoryExtension
    {
        public static IServiceCollection AddOfferRepository(this IServiceCollection services) {
            services.AddScoped<IOfferRepository, OfferRepository>();
            return services;
        }
    }
}
