using services_api.Application.Extensions;
using services_api.Domain.Repositories;
using services_api.Infrastructure.Repositories;

namespace services_api.Infrastructure.Extensions
{
    public static class SectionRepositoryExtension
    {
        public static IServiceCollection AddSectionRepository(this IServiceCollection services) {
            services.AddScoped<ISectionRepository, SectionRpository>();
            return services;
        }
    }
}
