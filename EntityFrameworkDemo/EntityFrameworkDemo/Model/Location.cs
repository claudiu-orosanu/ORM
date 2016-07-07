namespace EntityFrameworkDemo.Model
{
    public class Location
    {
        public long? LocationId { get; set; }

        public string StreetAddress { get; set; }
        
        public string PostalCode { get; set; }
        
        public string City { get; set; }
        
        public string StateProvince { get; set; }
    }
}
