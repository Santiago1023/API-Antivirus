using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IBootcamp
    {
        Task<IEnumerable<BootcampResponseDto>> GetAllAsync();
        Task<BootcampResponseDto> GetByIdAsync(long id);
        Task CreateAsync(BootcampRequestDto dto);
        Task UpdateAsync(long id, BootcampRequestDto dto);
        Task DeleteAsync(long id);
    }
}