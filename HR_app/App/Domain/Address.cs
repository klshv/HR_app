namespace HR_app.App.Domain
{
    public record Address
    {
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string Region { get; set; } = "";
        public string HouseNumber { get; set; } = "";
        public int PostalCode { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
