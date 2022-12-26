using AutoMapper;
using HR_app.App.Domain;
using HR_app.App.Interfaces.DataServices;
using HR_app.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_app.Data.Services
{

    public class ApplicantDataService : IApplicantDataService
    {
        public ApplicantDataService(HRAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int GetCount()
        {
            return _dbContext.Applicants.Count();
        }

        public IEnumerable<Applicant> GetAll(int pageIndex, int pageSize)
        {
            return _dbContext.Applicants
                .Include(x => x.Person)
                .Select(x => _mapper.Map<Applicant>(x))
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
        }

        public Applicant? Get(int id)
        {
            return GetEntityById(id)
                .Select(x => _mapper.Map<Applicant>(x))
                .FirstOrDefault();
        }

        public async Task<Applicant> CreateAsync(Applicant newApplicant)
        {
            ApplicantEntity newApplicantEntity = _mapper.Map<ApplicantEntity>(newApplicant);
            var createdApplicantEntity = await _dbContext.Applicants.AddAsync(newApplicantEntity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Applicant>(createdApplicantEntity.Entity);
        }

        public async Task UpdateAsync(Applicant updatedApplicant)
        {
            var applicantToUpdate = GetEntityById(updatedApplicant.Id).First();
            var updatedApplicantEntity = _mapper.Map<ApplicantEntity>(updatedApplicant);
            applicantToUpdate.Overwrite(updatedApplicantEntity);
            _dbContext.Applicants.Update(applicantToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int applicantId)
        {
            _dbContext.ChangeTracker.CascadeDeleteTiming = Microsoft.EntityFrameworkCore.ChangeTracking.CascadeTiming.Immediate;

            var applicantEntityBeingDeleted = GetEntityById(applicantId).First();
            _dbContext.Applicants.Remove(applicantEntityBeingDeleted);
            _dbContext.ChangeTracker.CascadeChanges();
            await _dbContext.SaveChangesAsync();
        }

        private IEnumerable<ApplicantEntity> GetEntityById(int id) =>
            _dbContext.Applicants
                .Include(x => x.Person)
                .ThenInclude(p => p.ContactData)
                .ThenInclude(c => c.HomeAddress)
                .Where(x => x.Id == id);

        private readonly HRAppDbContext _dbContext;
        private readonly IMapper _mapper;
    }
}
