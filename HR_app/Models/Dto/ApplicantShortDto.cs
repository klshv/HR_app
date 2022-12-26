using HR_app.Models.Enums;

namespace HR_app.Models.Dto
{
    public class ApplicantShortDto
    {
        public int Id { get; set; }
        public Decision Decision { get; set; } = Decision.Pending;
        public DateTime AppliedDate { get; set; } = DateTime.MinValue;
        public PersonShortDto Person { get; set; } = new();
    }
}
