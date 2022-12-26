using HR_app.Data.Enums;

namespace HR_app.Data.Entities
{
    public class ApplicantEntity
    {
        public int Id { get; set; } = 0;
        public DateTime AppliedDate { get; set; } = DateTime.MinValue;
        public string Position { get; set; } = String.Empty;
        public Decision Decision { get; set; } = Decision.Pending;

        public int PersonId { get; set; }
        public PersonEntity Person { get; set; } = new();

        public void Overwrite(ApplicantEntity updatedApplicant)
        {
            AppliedDate = updatedApplicant.AppliedDate;
            Position = updatedApplicant.Position;
            Decision = updatedApplicant.Decision;
            Person.Overwrite(updatedApplicant.Person);
        }
    }


}
