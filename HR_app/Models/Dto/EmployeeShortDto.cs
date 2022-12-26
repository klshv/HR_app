namespace HR_app.Models.Dto
{
    public class EmployeeShortDto
    {
        public int Id { get; set; }
        public string Position { get; set; } = String.Empty;
        public DateTime HiredDate { get; set; } = DateTime.MinValue;
        public PersonShortDto Person { get; set; } = new();
    }
}
