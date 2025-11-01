namespace services_api.Application.Extensions
{
    public static class AddDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddOfferService();
            return services;
        }
    }
}
