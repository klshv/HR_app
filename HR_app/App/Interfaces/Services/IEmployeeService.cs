using HR_app.App.Domain;

namespace HR_app.App.Interfaces.Services
{
    public interface IEmployeeService
    {
       
        IEnumerable<Employee> GetAll(int pageIndex, int pageSize);
        int GetCount();
        Employee? GetById(int id);
        Task<Employee> CreateAsync(Employee newEmployee);
        Task UpdateAsync(int id, Employee employee);
        Task DeleteAsync(int id);
    }
}
