using Microsoft.EntityFrameworkCore;
using services_api.Domain.Entities;
using services_api.Domain.Repositories;
using services_api.Infrastructure.Data;

namespace services_api.Infrastructure.Repositories
{
    public class SectionRpository : ISectionRepository
    {
        private readonly AppdbContext _db;
        public SectionRpository(AppdbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Section>> GetAllAsync()
        {
            return await _db.Sections.Include(s=>s.Offers).ToListAsync();

        }
        public async Task<Section> GetByIdAsync(int id)
        {
            return await _db.Sections.Include(s => s.Offers).FirstOrDefaultAsync(i=>i.Id == id);
        }
        public Task AddSectionAsync(Section section)
        {
            _db.Sections.Add(section);
            _db.SaveChangesAsync();
            return Task.CompletedTask;
        }
        
        public Task UpdateSectionAsync(Section section)
        {
            _db.Update(section);
            _db.SaveChangesAsync();
            return Task.CompletedTask;
        }
        public Task DeleteSectionAsync(Section section)
        {
            _db.Remove(section);
            _db.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
