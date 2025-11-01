using services_api.Application.Services;

namespace services_api.Application.Extensions
{
    public static class OfferServiceExtension
    {
        public static IServiceCollection AddOfferService(this IServiceCollection services)
        {
            services.AddScoped<IOfferService, OfferService>();
            return services;
        }
    }
}
