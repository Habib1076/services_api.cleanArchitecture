using services_api.Application.Services;

namespace services_api.Application.Extensions
{
    public static class SectionServiceExtension
    {
        public static IServiceCollection AddSectionService(this IServiceCollection services)
        {
            services.AddScoped<ISectionService, SectionService>();
            return services;
        }
    }
}
