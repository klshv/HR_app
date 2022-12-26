namespace HR_app.Models.Dto
{
    public class EmployeeListDto
    {
        public int Count { get; set; } = 0;
        public IEnumerable<EmployeeShortDto> Employees { get; set; } = new List<EmployeeShortDto>();
    }

}
