namespace HR_app.Models.Dto
{
    public record AddressDto
    {
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string Region { get; set; } = "";
        public string HouseNumber { get; set; } = "";
        public int PostalCode { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
