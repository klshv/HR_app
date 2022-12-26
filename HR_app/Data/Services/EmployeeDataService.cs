using AutoMapper;
using HR_app.App.Domain;
using HR_app.App.Interfaces.DataServices;
using HR_app.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_app.Data.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        public EmployeeDataService(HRAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int GetCount()
        {
            return _dbContext.Employees.Count();
        }

        public IEnumerable<Employee> GetAll(int pageIndex, int pageSize)
        {
            return _dbContext.Employees
                .Include(x => x.Person)
                .Select(x => _mapper.Map<Employee>(x))
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
        }

        public Employee? Get(int id)
        {
            return GetEntityById(id)
                .Select(x => _mapper.Map<Employee>(x))
                .FirstOrDefault();
        }

        public async Task<Employee> CreateAsync(Employee newEmployee)
        {
            EmployeeEntity newEmployeeEntity = _mapper.Map<EmployeeEntity>(newEmployee);
            var createdEmployeeEntity = await _dbContext.Employees.AddAsync(newEmployeeEntity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Employee>(createdEmployeeEntity.Entity);
        }

        public async Task UpdateAsync(Employee updatedEmployee)
        {
            var employeeToUpdate = GetEntityById(updatedEmployee.Id).First();
            var updatedEmployeeEntity = _mapper.Map<EmployeeEntity>(updatedEmployee);
            employeeToUpdate.Overwrite(updatedEmployeeEntity);
            _dbContext.Employees.Update(employeeToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId)
        {
            _dbContext.ChangeTracker.CascadeDeleteTiming = Microsoft.EntityFrameworkCore.ChangeTracking.CascadeTiming.Immediate;

            var employeeEntityBeingDeleted = GetEntityById(employeeId).First();
            _dbContext.Employees.Remove(employeeEntityBeingDeleted);
            _dbContext.ChangeTracker.CascadeChanges();
            await _dbContext.SaveChangesAsync();
        }

        private IEnumerable<EmployeeEntity> GetEntityById(int id) =>
            _dbContext.Employees
                .Include(x => x.Person)
                .ThenInclude(p => p.ContactData)
                .ThenInclude(c => c.HomeAddress)
                .Where(x => x.Id == id);

        private readonly HRAppDbContext _dbContext;
        private readonly IMapper _mapper;
    }
}
