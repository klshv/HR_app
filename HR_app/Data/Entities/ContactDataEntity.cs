namespace HR_app.Data.Entities
{
    public class ContactDataEntity
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public AddressEntity HomeAddress { get; set; } = new();

        public void Overwrite(ContactDataEntity updatedContactData)
        {
            Email = updatedContactData.Email;
            PhoneNumber = updatedContactData.PhoneNumber;
            HomeAddress.Overwrite(updatedContactData.HomeAddress);
        }
    }
}
