using Api_Antivirus.Models;

namespace Api_Antivirus.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task CreateAsync (User user);
        Task UpdateAsync (User user);
        Task DeleteAsync (int id);
    }
}