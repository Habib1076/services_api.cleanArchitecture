namespace services_api.Application.DTOs
{
    public class GetSectionsDTO
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public string SectionDescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
