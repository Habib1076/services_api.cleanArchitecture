namespace services_api.Application.DTOs
{
    public class OfferResponseDTO
    {
        public int Id { get; set; }
        public string OfferName { get; set; }
        public string OfferDescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
