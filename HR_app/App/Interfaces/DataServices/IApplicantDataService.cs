using HR_app.App.Domain;

namespace HR_app.App.Interfaces.DataServices
{
    public interface IApplicantDataService
    {
        IEnumerable<Applicant> GetAll(int pageIndex, int pageSize);
        int GetCount();
        Applicant? Get(int id);
        Task<Applicant> CreateAsync(Applicant newPerson);
        Task UpdateAsync(Applicant updatedApplicant);
        Task DeleteAsync(int id);
    }
}
