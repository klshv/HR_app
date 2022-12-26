using HR_app.App.Enums;

namespace HR_app.App.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public DateTime HiredDate { get; set; } = DateTime.MinValue;
        public int Salary { get; set; } = 0;
        public LevelType? LevelType { get; set; }
        public string Position { get; set; } = String.Empty;
        public Person Person { get; set; } = new();
    }
}
