using HR_app.App.Domain;

namespace HR_app.App.Interfaces.Services
{
    public interface IApplicantService
    {
        IEnumerable<Applicant> GetAll(int pageIndex, int pageSize);
        int GetCount();
        Applicant? GetById(int id);
        Task<Applicant> CreateAsync(Applicant newApplicant);
        Task UpdateAsync(int id, Applicant applicant);
        Task DeleteAsync(int id);
    }
}
