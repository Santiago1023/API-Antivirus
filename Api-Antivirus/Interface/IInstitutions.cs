using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IInstitutions
    {
        Task<IEnumerable<InstitutionsResponseDto>> GetAllAsync();
        Task<InstitutionsResponseDto> GetByIdAsync(long id);
        Task CreateAsync(InstitutionsRequestDto dto);
        Task UpdateAsync(long id, InstitutionsRequestDto dto);
        Task DeleteAsync(long id);
    }
}