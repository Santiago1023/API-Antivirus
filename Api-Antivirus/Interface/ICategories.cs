using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface ICategories
    {
        Task<IEnumerable<CategoriesResponseDto>> GetAllAsync();
        Task<CategoriesResponseDto> GetByIdAsync(int  id);
        Task CreateAsync(CategoriesRequestDto dto);
        Task UpdateAsync(int  id, CategoriesRequestDto dto);
        Task DeleteAsync(int  id);
    }
}