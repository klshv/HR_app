using HR_app.App.Enums;

namespace HR_app.App.Domain
{
    public class Applicant
    {
        public int Id { get; set; } = 0;
        public DateTime AppliedDate { get; set; } = DateTime.MinValue;
        public string Position { get; set; } = string.Empty;
        public Decision Decision { get; set; } = Decision.Pending;
        public Person Person { get; set; } = new();
    }
}
