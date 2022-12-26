namespace HR_app.Models.Dto
{
    public class ApplicantListDto
    {
        public int Count { get; set; } = 0;
        public IEnumerable<ApplicantShortDto> Applicants { get; set; } = new List<ApplicantShortDto>();
    }
}
