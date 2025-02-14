
using Api_Antivirus.Models;

namespace Api_Antivirus.Services
{
    public interface IUser_OpportunityService
    {
        Task <IEnumerable<User_Opportunity>> GetAllAsync();        
        Task<User_Opportunity?> GetByIdAsync(int id);
        Task CreateAsync (User_Opportunity user_Opportunity);
        Task UpdateAsync (User_Opportunity user_Opportunity);
        Task DeleteAsync (int id);
    }
}