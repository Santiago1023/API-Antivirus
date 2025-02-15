using Api_Antivirus.Models;

namespace  Api_Antivirus.Services
{
    public interface IOpportunityService
    {
        Task<IEnumerable<Opportunity>> GetAllAsync();
        Task<Opportunity?> GetByIdAsync(int id);
        Task<Opportunity> CreateAsync(Opportunity opportunity);
        Task<bool> UpdateAsync(Opportunity opportunity);
        Task<bool> DeleteAsync(int id);
    }
}