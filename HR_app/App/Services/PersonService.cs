using HR_app.App.Domain;
using HR_app.App.Interfaces.DataServices;
using HR_app.Interfaces.Services;

namespace HR_app.Services;

public class PersonService : IPersonService
{
    public PersonService(IPersonDataService personDataService)
    {
        _personDataService = personDataService;
    }

    public int GetCount()
    {
        return _personDataService.GetCount();
    }

    public IEnumerable<Person> GetAll(int pageIndex, int pageSize)
    {
        return _personDataService.GetAll(pageIndex, pageSize);
    }

    public Person GetById(int id)
    {
        return _personDataService.Get(id);
    }

    public async Task CreateAsync(Person newPerson)
    {
        await _personDataService.CreateAsync(newPerson);
    }

    private readonly IPersonDataService _personDataService;
}