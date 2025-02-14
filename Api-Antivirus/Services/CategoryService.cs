using Api_Antivirus.Data;
using Api_Antivirus.Models;
using Microsoft.EntityFrameworkCore;


namespace Api_Antivirus.Services 
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task <IEnumerable<Category>> GetAllAsync ()
        {  
            return await _context.Categories.ToListAsync();
        }
        public async Task <Category?> GetByIdAsync(int id)
        {
            var servIndividual= await _context.Categories.FindAsync(id);
            if (servIndividual != null)
            {
                return servIndividual;
            }
            Console.WriteLine("Servicio No encontrado");
            return null;
        }
        public async Task CreateAsync (Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            category.Id = category.Id;
        }
        public async Task UpdateAsync (Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync  (int id)
        {
            var service =await _context.Categories.FindAsync(id);
            if (service != null)
            {
                _context.Categories.Remove(service);
                await _context.SaveChangesAsync();
            }
        }
    }
}