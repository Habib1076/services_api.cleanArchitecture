namespace services_api.Application.DTOs
{

    public class AddOfferRequestDTO
    {
        public string OfferName { get; set; }
        public string OfferDescription { get; set; }
        public int SectiontId { get; set; }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(OfferName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(OfferDescription)) { 
                return false;   
            }
            return true;    
        }
    }
}
