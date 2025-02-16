using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IBootcampTopic
    {
        Task<IEnumerable<BootcampTopicResponseDto>> GetAllAsync();
        Task<BootcampTopicResponseDto> GetByIdAsync(long id);
        Task CreateAsync(BootcampTopicRequestDto dto);
        Task UpdateAsync(long id, BootcampTopicRequestDto dto);
        Task DeleteAsync(long id);
    }
}