using HR_app.App.Domain;
using HR_app.App.Interfaces.DataServices;
using HR_app.App.Interfaces.Services;

namespace HR_app.App.Services
{
    public class ApplicantService : IApplicantService
    {
        public ApplicantService(IApplicantDataService applicantDataService)
        {
            _applicantDataService = applicantDataService;
        }

        public int GetCount()
        {
            return _applicantDataService.GetCount();
        }

        public IEnumerable<Applicant> GetAll(int pageIndex, int pageSize)
        {
            return _applicantDataService.GetAll(pageIndex, pageSize);
        }

        public Applicant? GetById(int id)
        {
            return _applicantDataService.Get(id);
        }

        public async Task<Applicant> CreateAsync(Applicant newApplicant)
        {
            return await _applicantDataService.CreateAsync(newApplicant);
        }

        public async Task UpdateAsync(int id, Applicant applicant)
        {
            applicant.Id = id;
            await _applicantDataService.UpdateAsync(applicant);
        }

        public async Task DeleteAsync(int id)
        {
            await _applicantDataService.DeleteAsync(id);
        }

        private readonly IApplicantDataService _applicantDataService;   
    }
}
