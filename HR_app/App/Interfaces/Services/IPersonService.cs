
using HR_app.App.Domain;

namespace HR_app.Interfaces.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll(int pageIndex, int pageSize);
        int GetCount();
        Person GetById(int id);
        Task CreateAsync(Person newPerson);
    }
}
