namespace services_api.Application.DTOs
{
    public class SectionRequestDTO
    {
        public string SectionName { get; set; }
        public string SectionDescription { get; set; }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(SectionName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(SectionDescription)) { 
                return false;   
            }
            return true;    
        }
    }
}
