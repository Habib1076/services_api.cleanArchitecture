using services_api.Domain.Entities;

namespace services_api.Domain.Repositories
{
    public interface IOfferRepository
    {
        Task<IEnumerable<Offer>> GetAllAsync();
        Task<Offer> GetByIdAsync(int id);
        Task AddOfferAsync(Offer offer);
        Task UpdateOfferAsync(Offer offer);
        Task DeleteOfferAsync(Offer offer);
    }
}
