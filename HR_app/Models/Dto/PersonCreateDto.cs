namespace HR_app.Models.Dto
{
    public class PersonCreateDto
    {
        public string FirstName { get; set; } = String.Empty;
        public string Patronymic { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public DateTime Birthday { get; set; } = DateTime.MinValue;
    }
}
