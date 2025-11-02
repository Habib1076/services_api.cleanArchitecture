using services_api.Domain.Entities;

namespace services_api.Domain.Repositories
{
    public interface ISectionRepository
    {
        Task<IEnumerable<Section>> GetAllAsync();
        Task<Section> GetByIdAsync(int id);
        Task AddSectionAsync(Section section);
        Task UpdateSectionAsync(Section section);
        Task DeleteSectionAsync(Section section);
    }
}
