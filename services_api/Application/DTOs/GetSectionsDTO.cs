using services_api.Domain.Entities;

namespace services_api.Application.DTOs
{
    public class GetSectionsDTO
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public string SectionDescription { get; set; }
        public ICollection<GetOffersDTO> Offers { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
