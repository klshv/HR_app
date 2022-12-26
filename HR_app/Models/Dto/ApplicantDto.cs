using HR_app.Models.Enums;

namespace HR_app.Models.Dto
{
    public class ApplicantDto
    {
        public DateTime AppliedDate { get; set; } = DateTime.MinValue;
        public string Position { get; set; } = String.Empty;
        public Decision Decision { get; set; } = Decision.Pending;
        public PersonDto Person { get; set; } = new();

    }
}
