using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api_Antivirus.Data;
using Api_Antivirus.Models;
using Api_Antivirus.Services;

namespace Api_Antivirus.Services
{
    public class InstitutionBootcampService : IInstitutionBootcampService
    {
        private readonly ApplicationDbContext _context;

        public InstitutionBootcampService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InstitutionBootcamp>> GetAllInstitutionBootcampsAsync()
        {
            return await _context.InstitutionBootcamps.ToListAsync();
        }

        public async Task<InstitutionBootcamp> GetInstitutionBootcampByIdAsync(int id)
        {
            return await _context.InstitutionBootcamps.FindAsync(id);
        }

        public async Task<InstitutionBootcamp> CreateInstitutionBootcampAsync(InstitutionBootcamp institutionBootcamp)
        {
            _context.InstitutionBootcamps.Add(institutionBootcamp);
            await _context.SaveChangesAsync();
            return institutionBootcamp;
        }

        public async Task<InstitutionBootcamp?> UpdateInstitutionBootcampAsync(int id, InstitutionBootcamp institutionBootcamp)
        {
            var existingBootcamp = await _context.InstitutionBootcamps.FindAsync(id);
            if (existingBootcamp == null) return null;

            _context.Entry(existingBootcamp).CurrentValues.SetValues(institutionBootcamp);
            await _context.SaveChangesAsync();
            return existingBootcamp;
        }

        public async Task<bool> DeleteInstitutionBootcampAsync(int id)
        {
            var institutionBootcamp = await _context.InstitutionBootcamps.FindAsync(id);
            if (institutionBootcamp == null) return false;

            _context.InstitutionBootcamps.Remove(institutionBootcamp);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
