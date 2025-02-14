using Api_Antivirus.Models;
using Api_Antivirus.Data;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Services
{
    public class UserService : IUserService
    {
        
        private readonly ApplicationDbContext _context;   

        public UserService (ApplicationDbContext context)
        {
            _context = context;
        }

        //implementar los Servicios
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            User? user = await _context.Users.FindAsync(id);
            //verifica si el usuario exite 
            if (user != null)
            {
                return user;
            }
            else
            {
                Console.WriteLine( "Usuario no encontrado");
                return null;
            }
        }
        public async Task CreateAsync (User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            user.Id = user.Id; 
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync (int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}