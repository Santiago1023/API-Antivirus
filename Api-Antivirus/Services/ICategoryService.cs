using Api_Antivirus.Models;

namespace Api_Antivirus.Services
{
    public interface ICategoryService
    {
        Task <IEnumerable<Category>> GetAllAsync();        
        Task<Category?> GetByIdAsync(int id);
        Task CreateAsync (Category category);
        Task UpdateAsync (Category category);
        Task DeleteAsync (int id);
    }
}