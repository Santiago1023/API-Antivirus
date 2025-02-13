using Microsoft.EntityFrameworkCore;
using Api_Antivirus.Data;
using Api_Antivirus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Antivirus.Services
{
    public class InstitutionService
    {
        private readonly ApplicationDbContext _context;

        public InstitutionService(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔹 Obtener todas las instituciones
        public async Task<IEnumerable<Institution>> GetAllInstitutionsAsync()
        {
            return await _context.Institutions.ToListAsync();
        }

        // 🔹 Obtener una institución por ID
        public async Task<Institution?> GetInstitutionByIdAsync(int id)
        {
            return await _context.Institutions.FindAsync(id);
        }

        // 🔹 Crear una nueva institución
        public async Task<Institution> CreateInstitutionAsync(Institution institution)
        {
            _context.Institutions.Add(institution);
            await _context.SaveChangesAsync();
            return institution;
        }

        // 🔹 Actualizar una institución
        public async Task<Institution?> UpdateInstitutionAsync(int id, Institution institution)
        {
            var existingInstitution = await _context.Institutions.FindAsync(id);
            if (existingInstitution == null)
            {
                return null;
            }

            existingInstitution.Name = institution.Name;
            existingInstitution.Location = institution.Location;
            existingInstitution.UrlGeneral = institution.UrlGeneral;
            existingInstitution.UrlAcademicOffers = institution.UrlAcademicOffers;
            existingInstitution.UrlWellbeing = institution.UrlWellbeing;
            existingInstitution.UrlAdmission = institution.UrlAdmission;

            await _context.SaveChangesAsync();
            return existingInstitution;
        }

        // 🔹 Eliminar una institución
        public async Task<bool> DeleteInstitutionAsync(int id)
        {
            var institution = await _context.Institutions.FindAsync(id);
            if (institution == null)
            {
                return false;
            }

            _context.Institutions.Remove(institution);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
