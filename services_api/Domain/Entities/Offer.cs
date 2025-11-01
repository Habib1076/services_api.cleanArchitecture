
namespace services_api.Domain.Entities
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        //public int SectionId { get; set; }
        //public Section Section { get; set; } = default!;
    }
}
