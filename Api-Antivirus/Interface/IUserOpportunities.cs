using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IUserOpportunities
    {
        Task<IEnumerable<UserOpportunitiesResponseDto>> GetAllAsync();
        Task<UserOpportunitiesResponseDto> GetByIdAsync(long id);
        Task CreateAsync(UserOpportunitiesRequestDto dto);
        Task UpdateAsync(long id, UserOpportunitiesRequestDto dto);
        Task DeleteAsync(long id);
    }
}