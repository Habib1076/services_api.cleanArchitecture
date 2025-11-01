namespace services_api.Application.DTOs
{
    public class OfferRequestDTO
    {
        public string OfferName { get; set; }
        public string OfferDescription { get; set; }
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
