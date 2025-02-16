using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface ICategories
    {
        Task<IEnumerable<CategoriesResponseDto>> GetAllAsync();
        Task<CategoriesResponseDto> GetByIdAsync(long id);
        Task CreateAsync(CategoriesRequestDto dto);
        Task UpdateAsync(long id, CategoriesRequestDto dto);
        Task DeleteAsync(long id);
    }
}