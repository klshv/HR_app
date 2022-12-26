namespace HR_app.Data.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }

        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string Region { get; set; } = "";
        public string HouseNumber { get; set; } = "";
        public int PostalCode { get; set; }
        public int ApartmentNumber { get; set; }

        public void Overwrite(AddressEntity updatedAddress)
        {
            Street = updatedAddress.Street;
            City = updatedAddress.City;
            Region = updatedAddress.Region;
            HouseNumber = updatedAddress.HouseNumber;
            PostalCode = updatedAddress.PostalCode;
            ApartmentNumber = updatedAddress.ApartmentNumber;
        }
    }
}
