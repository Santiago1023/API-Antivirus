using Microsoft.EntityFrameworkCore;
using Api_Antivirus.Data;
using Api_Antivirus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Antivirus.Services
{
    public class BootcampService
    {
        private readonly ApplicationDbContext _context;

        public BootcampService(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔹 Obtener todos los bootcamps
        public async Task<IEnumerable<Bootcamp>> GetAllBootcampsAsync()
        {
            return await _context.Bootcamps.Include(b => b.Institution).ToListAsync();
        }

        // 🔹 Obtener un bootcamp por ID
        public async Task<Bootcamp?> GetBootcampByIdAsync(int id)
        {
            return await _context.Bootcamps.Include(b => b.Institution).FirstOrDefaultAsync(b => b.Id == id);
        }

        // 🔹 Crear un nuevo bootcamp
        public async Task<Bootcamp> CreateBootcampAsync(Bootcamp bootcamp)
        {
            // Si el Bootcamp tiene una Institución asociada, buscarla
            if (bootcamp.InstitutionId.HasValue)
            {
                var institution = await _context.Institutions.FindAsync(bootcamp.InstitutionId);
                if (institution != null)
                {
                    bootcamp.Institution = institution;
                }
            }

            // Agregar el Bootcamp a la base de datos
            _context.Bootcamps.Add(bootcamp);
            await _context.SaveChangesAsync();

            return bootcamp;
        }


        // 🔹 Actualizar un bootcamp
        public async Task<Bootcamp?> UpdateBootcampAsync(int id, Bootcamp bootcamp)
        {
            // Buscar el Bootcamp existente junto con su Institución
            var existingBootcamp = await _context.Bootcamps
                .Include(b => b.Institution)
                .FirstOrDefaultAsync(b => b.Id == id);
            
            if (existingBootcamp == null) return null;

            // Actualizar los campos del Bootcamp
            existingBootcamp.Name = bootcamp.Name;
            existingBootcamp.Description = bootcamp.Description;
            existingBootcamp.Information = bootcamp.Information;
            existingBootcamp.Costs = bootcamp.Costs;

            // Si la Institución cambió, actualizarla
            if (existingBootcamp.InstitutionId != bootcamp.InstitutionId)
            {
                if (bootcamp.InstitutionId.HasValue)
                {
                    var institution = await _context.Institutions.FindAsync(bootcamp.InstitutionId);
                    if (institution == null) return null; // Evitar errores si la Institución no existe

                    existingBootcamp.InstitutionId = bootcamp.InstitutionId;
                    existingBootcamp.Institution = institution;
                }
                else
                {
                    // Si se establece a null, eliminar la relación
                    existingBootcamp.InstitutionId = null;
                    existingBootcamp.Institution = null;
                }
            }

            // Guardar cambios en la base de datos
            _context.Bootcamps.Update(existingBootcamp);
            await _context.SaveChangesAsync();
            
            return existingBootcamp;
        }


        // 🔹 Eliminar un bootcamp
        public async Task<bool> DeleteBootcampAsync(int id)
        {
            // Buscar el Bootcamp en la base de datos
            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if (bootcamp == null) return false;

            // Eliminar el Bootcamp directamente, ya que la relación con Institution es directa
            _context.Bootcamps.Remove(bootcamp);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
