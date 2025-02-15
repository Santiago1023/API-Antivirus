
using Api_Antivirus.Dto;

namespace Api_Antivirus.Services
{
    public interface ITopicService
    {
        Task<IEnumerable<TopicDto>>GetAllAsync();
        Task<TopicDto>GetByIdAsync(int id);
        Task CreateAsync(TopicDto topic);
        Task UpdateAsync(int id, TopicDto topic);
        Task DeleteAsync(int id);


    }
}