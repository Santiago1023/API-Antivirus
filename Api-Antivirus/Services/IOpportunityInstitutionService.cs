using Api_Antivirus.Models;

namespace  Api_Antivirus.Services
{
    public interface IOpportunityInstitutionService
    {
        Task<IEnumerable<OpportunityInstitution>> GetAllAsync();
        Task<OpportunityInstitution?> GetByIdAsync(int id);
        Task<OpportunityInstitution> CreateAsync(OpportunityInstitution opportunityinstitution);
        Task<bool> UpdateAsync(OpportunityInstitution opportunityinstitution);
        Task<bool> DeleteAsync(int id);
    }
}