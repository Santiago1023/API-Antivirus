using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Antivirus.Models;

namespace Api_Antivirus.Services
{
    public interface IBootcampTopicsService
    {
        Task<IEnumerable<BootcampTopics>> GetAllBootcampTopicsAsync();
        Task<BootcampTopics> GetBootcampTopicsByIdAsync(int id);
        Task<BootcampTopics> CreateBootcampTopicsAsync(BootcampTopics bootcampTopics);
        Task<BootcampTopics> UpdateBootcampTopicsAsync(int id, BootcampTopics bootcampTopics);
        Task<bool> DeleteBootcampTopicsAsync(int id);
    }
}