using AutoMapper;
using HR_app.App.Domain;
using HR_app.App.Interfaces.DataServices;
using HR_app.Data.Entities;

namespace HR_app.Data.Services
{
    public class PersonDataService : IPersonDataService
    {
        public PersonDataService(HRAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int GetCount()
        {
            return _dbContext.Persons.Count();
        }

        public IEnumerable<Person> GetAll(int pageIndex, int pageSize)
        {
            return _dbContext.Persons
                .Select(x => _mapper.Map<Person>(x))
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
        }

        public Person Get(int id)
        {
            return _dbContext.Persons
                .Where(x => x.PersonId == id)
                .Select(x => _mapper.Map<Person>(x))
                .First();
        }

        public async Task CreateAsync(Person newPerson)
        {
            PersonEntity newPersonEntity = _mapper.Map<PersonEntity>(newPerson);
            await _dbContext.Persons.AddAsync(newPersonEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person updatedPerson)
        {
            var personEntity = _mapper.Map<PersonEntity>(updatedPerson);
            _dbContext.Persons.Update(personEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int personId)
        {
            var personEntityBeingDeleted = _dbContext.Persons.First(x => x.PersonId == personId);
            _dbContext.Persons.Remove(personEntityBeingDeleted);
            await _dbContext.SaveChangesAsync();
        }

        private readonly HRAppDbContext _dbContext;
        private readonly IMapper _mapper;
    }
}
