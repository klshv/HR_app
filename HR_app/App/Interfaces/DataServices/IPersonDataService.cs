using HR_app.App.Domain;

namespace HR_app.App.Interfaces.DataServices
{
    public interface IPersonDataService
    {
        IEnumerable<Person> GetAll(int pageIndex, int pageSize);
        int GetCount();
        Person Get(int id);
        Task CreateAsync(Person newPerson);
        Task UpdateAsync(Person updatedPerson);
        Task DeleteAsync(int id);
    }
}
