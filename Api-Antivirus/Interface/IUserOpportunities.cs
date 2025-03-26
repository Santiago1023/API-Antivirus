using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IUserOpportunities
    {
        Task<IEnumerable<UserOpportunitiesResponseDto>> GetAllAsync();
        Task<UserOpportunitiesResponseDto> GetByIdAsync(int id);
        Task CreateAsync(UserOpportunitiesRequestDto dto);
        Task UpdateAsync(int id, UserOpportunitiesRequestDto dto);
        Task DeleteAsync(int id);
    }
}