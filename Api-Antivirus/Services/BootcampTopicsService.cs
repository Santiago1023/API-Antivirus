using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api_Antivirus.Data;
using Api_Antivirus.Models;


namespace Api_Antivirus.Services
{
    public class BootcampTopicsService : IBootcampTopicsService
    {
        private readonly ApplicationDbContext _context;

        public BootcampTopicsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BootcampTopics>> GetAllBootcampTopicsAsync()
        {
            return await _context.BootcampTopics.ToListAsync();
        }

        public async Task<BootcampTopics> GetBootcampTopicsByIdAsync(int id)
        {
            return await _context.BootcampTopics.FindAsync(id);
        }

        public async Task<BootcampTopics> CreateBootcampTopicsAsync(BootcampTopics bootcampTopics)
        {
            _context.BootcampTopics.Add(bootcampTopics);
            await _context.SaveChangesAsync();
            return bootcampTopics;
        }

        public async Task<BootcampTopics> UpdateBootcampTopicsAsync(int id, BootcampTopics bootcampTopics)
        {
            bootcampTopics.Id = id; // Asegúrate de que el ID del objeto coincida con el ID del parámetro
            _context.BootcampTopics.Update(bootcampTopics);
            await _context.SaveChangesAsync();
            return bootcampTopics;
        }

        public async Task<bool> DeleteBootcampTopicsAsync(int id)
        {
            var bootcampTopics = await _context.BootcampTopics.FindAsync(id);
            if (bootcampTopics == null) return false;

            _context.BootcampTopics.Remove(bootcampTopics);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}