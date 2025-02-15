using Microsoft.EntityFrameworkCore;
using Api_Antivirus.Data;
using OpportunitiesAPI.Models;


namespace OpportunitiesAPI.Services
using Api_Antivirus.Models;


//namespace  Api_Antivirus.Services
{
    public class OpportunityService : IOpportunityService
    {
        private readonly ApplicationDbContext _context;

        public OpportunityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Opportunity>> GetAllAsync()
        {
            return await _context.Opportunities.ToListAsync();
        }

        public async Task<Opportunity?> GetByIdAsync(int id)
        {
            return await _context.Opportunities.FindAsync(id);
        }

        public async Task<Opportunity> CreateAsync(Opportunity opportunity)
        {
            _context.Opportunities.Add(opportunity);
            await _context.SaveChangesAsync();
            return opportunity;
        }

        public async Task<bool> UpdateAsync(Opportunity opportunity)
        {
            _context.Opportunities.Update(opportunity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity == null) return false;

            _context.Opportunities.Remove(opportunity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
