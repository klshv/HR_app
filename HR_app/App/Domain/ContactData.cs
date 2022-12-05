namespace HR_app.App.Domain
{
    public record ContactData
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Address HomeAddress { get; set; } = new();
    }
}
