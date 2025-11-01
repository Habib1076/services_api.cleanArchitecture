namespace services_api.Domain.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
    }
}
