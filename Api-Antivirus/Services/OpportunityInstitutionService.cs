using Microsoft.EntityFrameworkCore;
using Api_Antivirus.Data;
using Api_Antivirus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Antivirus.Services
{
    public class OpportunityInstitutionService : IOpportunityInstitutionService
    {
        private readonly ApplicationDbContext _context;

        public OpportunityInstitutionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OpportunityInstitution>> GetAllAsync()
        {
            return await _context.OpportunityInstitutions
                .Include(oi => oi.Opportunity)
                .Include(oi => oi.Institution)
                .ToListAsync();
        }

        public async Task<OpportunityInstitution?> GetByIdAsync(int id)
        {
            return await _context.OpportunityInstitutions
                .Include(oi => oi.Opportunity)
                .Include(oi => oi.Institution)
                .FirstOrDefaultAsync(oi => oi.Id == id);
        }

        public async Task<OpportunityInstitution> CreateAsync(OpportunityInstitution opportunityInstitution)
        {
            _context.OpportunityInstitutions.Add(opportunityInstitution);
            await _context.SaveChangesAsync();
            return opportunityInstitution;
        }

        public async Task<bool> UpdateAsync(OpportunityInstitution opportunityInstitution)
        {
            _context.Entry(opportunityInstitution).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var opportunityInstitution = await _context.OpportunityInstitutions.FindAsync(id);
            if (opportunityInstitution == null)
            {
                return false;
            }

            _context.OpportunityInstitutions.Remove(opportunityInstitution);
            await _context.SaveChangesAsync();
            return true;
        }

        Task<IEnumerable<OpportunityInstitution>> IOpportunityInstitutionService.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
