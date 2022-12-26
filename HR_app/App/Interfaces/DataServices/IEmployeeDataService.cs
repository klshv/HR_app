using HR_app.App.Domain;

namespace HR_app.App.Interfaces.DataServices
{
    public interface IEmployeeDataService
    {

        IEnumerable<Employee> GetAll(int pageIndex, int pageSize);
        int GetCount();
        Employee? Get(int id);
        Task<Employee> CreateAsync(Employee newPerson);
        Task UpdateAsync(Employee updatedEmployee);
        Task DeleteAsync(int id);
    }
}
