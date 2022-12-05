namespace HR_app.Models.Dto
{
    public record ContactDataDto
    {
        public string Email { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public AddressDto HomeAddress { get; set; } = new();
    }
}
