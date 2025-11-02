using services_api.Domain.Entities;

namespace services_api.Application.DTOs
{
    public class AddOfferResponseDTO
    {
        public int Id { get; set; }
        public string OfferName { get; set; }
        public string OfferDescription { get; set; }
        public int SectionId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
