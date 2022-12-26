using HR_app.Models.Enums;

namespace HR_app.Models.Dto
{
    public class EmployeeDto
    {
        public DateTime HiredDate { get; set; } = DateTime.MinValue;
        public int Salary { get; set; } = 0;
        public LevelType? LevelType { get; set; }
        public string Position { get; set; } = String.Empty;
        public PersonDto Person { get; set; } = new();

    }
}
