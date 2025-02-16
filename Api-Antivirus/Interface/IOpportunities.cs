using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IOpportunities
    {
        Task<IEnumerable<OpportunitiesResponseDto>> GetAllAsync();
        Task<OpportunitiesResponseDto> GetByIdAsync(long id);
        Task CreateAsync(OpportunitiesRequestDto dto);
        Task UpdateAsync(long id, OpportunitiesRequestDto dto);
        Task DeleteAsync(long id);
    }
}