using HR_app.App.Domain;
using HR_app.App.Interfaces.DataServices;
using HR_app.App.Interfaces.Services;

namespace HR_app.App.Services
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeDataService employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }

        public int GetCount()
        {
            return _employeeDataService.GetCount();
        }

        public IEnumerable<Employee> GetAll(int pageIndex, int pageSize)
        {
            return _employeeDataService.GetAll(pageIndex, pageSize);
        }

        public Employee? GetById(int id)
        {
            return _employeeDataService.Get(id);
        }

        public async Task<Employee> CreateAsync(Employee newEmployee)
        {
            return await _employeeDataService.CreateAsync(newEmployee);
        }

        public async Task UpdateAsync(int id, Employee employee)
        {
            employee.Id = id;
            await _employeeDataService.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            await _employeeDataService.DeleteAsync(id);
        }

        private readonly IEmployeeDataService _employeeDataService;
    }
}
