namespace HR_app.Models.Dto
{
    public class ApplicantCreateDto
    {
        public string Position { get; set; } = String.Empty;
        public PersonDto Person { get; set; } = new();
    }
}
