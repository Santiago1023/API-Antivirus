using Microsoft.EntityFrameworkCore;
using Api_Antivirus.Data;
using Api_Antivirus.Dto;
using Api_Antivirus.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Antivirus.Services
{
    public class TopicService : ITopicService
    {
        private readonly ApplicationDbContext _context;

        public TopicService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TopicDto topicDto)
        {
            // Mapear el DTO a la entidad
            var topic = TopicMapper.MapTopic(topicDto);

            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TopicDto>> GetAllAsync()
        {
            var topics = await _context.Topics.ToListAsync();
            var topicDtos = new List<TopicDto>();

            foreach (var topic in topics)
            {
                topicDtos.Add(TopicMapper.MapTopicDto(topic));
            }

            return topicDtos;
        }

        public async Task<TopicDto> GetByIdAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            return topic != null ? TopicMapper.MapTopicDto(topic) : null;
        }

        public async Task UpdateAsync(int id, TopicDto topicDto)
        {
            var existingTopic = await _context.Topics.FindAsync(id);
            if (existingTopic != null)
            {
                // Actualizar la entidad con los datos del DTO
                existingTopic.Name = topicDto.Name;

                await _context.SaveChangesAsync();
            }
        }
    }
}