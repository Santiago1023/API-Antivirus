using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface ITopic
    {
        Task<IEnumerable<TopicResponseDto>> GetAllAsync();
        Task<TopicResponseDto> GetByIdAsync(long id);
        Task CreateAsync(TopicRequestDto dto);
        Task UpdateAsync(long id, TopicRequestDto dto);
        Task DeleteAsync(long id);
    }
}