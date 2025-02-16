using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IUsers
    {
        Task<IEnumerable<UsersResponseDto>> GetAllAsync();
        Task<UsersResponseDto> GetByIdAsync(long id);
        Task CreateAsync(UsersRequestDto dto);
        Task UpdateAsync(long id, UsersRequestDto dto);
        Task DeleteAsync(long id);
    }
}