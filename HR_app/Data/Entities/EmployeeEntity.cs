using HR_app.Data.Enums;

namespace HR_app.Data.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public DateTime HiredDate { get; set; } = DateTime.MinValue;
        public int Salary { get; set; } = 0;
        public LevelType? LevelType { get; set; } 
        public string Position { get; set; } = String.Empty;


        public int PersonId { get; set; }
        public PersonEntity Person { get; set; } = new();

        public void Overwrite(EmployeeEntity updatedEmployee)
        {
            HiredDate = updatedEmployee.HiredDate;
            Salary = updatedEmployee.Salary;
            LevelType = updatedEmployee.LevelType;
            Position = updatedEmployee.Position;
            Person.Overwrite(updatedEmployee.Person);
        }
    }
}
