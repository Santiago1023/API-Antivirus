using Api_Antivirus.Data;
using Api_Antivirus.Models;
using Microsoft.EntityFrameworkCore;


namespace Api_Antivirus.Services
{
    public class User_OpportunityService : IUser_OpportunityService
    {
        private readonly ApplicationDbContext _context;
        public User_OpportunityService (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task <IEnumerable<User_Opportunity>> GetAllAsync ()
        {  
            return await _context.UserOpportunities.ToListAsync();
        }
        public async Task <User_Opportunity?> GetByIdAsync(int id)
        {
            var userOpportunity= await _context.UserOpportunities.FindAsync(id);
            if (userOpportunity != null)
            {
                return userOpportunity;
            }
            Console.WriteLine("Servicio No encontrado");
            return null;
        }
        public async Task CreateAsync (User_Opportunity user_Opportunity)
        {
            _context.UserOpportunities.Add(user_Opportunity);
            await _context.SaveChangesAsync();
            user_Opportunity.Id = user_Opportunity.Id;
        }
        public async Task UpdateAsync (User_Opportunity user_Opportunity)
        {
            _context.UserOpportunities.Update(user_Opportunity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync  (int id)
        {
            var userOpportunity =await _context.UserOpportunities.FindAsync(id);
            if (userOpportunity != null)
            {
                _context.UserOpportunities.Remove(userOpportunity);
                await _context.SaveChangesAsync();
            }
        }
    }
}