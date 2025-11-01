using Microsoft.EntityFrameworkCore;
using services_api.Domain.Entities;
using services_api.Domain.Repositories;
using services_api.Infrastructure.Data;

namespace services_api.Infrastructure.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AppdbContext _db;
        public OfferRepository(AppdbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Offer>> GetAllAsync()
        {
            return await _db.Offers.ToListAsync();

        }
        public async Task<Offer> GetByIdAsync(int id)
        {
            return await _db.Offers.FindAsync(id);
        }
        public Task AddOfferAsync(Offer offer)
        {
            _db.Offers.Add(offer);
            _db.SaveChangesAsync();
            return Task.CompletedTask;
        }
        
        public Task UpdateOfferAsync(Offer offer)
        {
            _db.Update(offer);
            _db.SaveChangesAsync();
            return Task.CompletedTask;
        }
        public Task DeleteOfferAsync(Offer offer)
        {
            _db.Remove(offer);
            _db.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
