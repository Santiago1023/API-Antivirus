using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IOpportunities
    {
        Task<IEnumerable<OpportunitiesResponseDto>> GetAllAsync();
        Task<OpportunitiesResponseDto> GetByIdAsync(int id);
        Task CreateAsync(OpportunitiesRequestDto dto);
        Task UpdateAsync(int id, OpportunitiesRequestDto dto);
        Task DeleteAsync(int id);
    }
}