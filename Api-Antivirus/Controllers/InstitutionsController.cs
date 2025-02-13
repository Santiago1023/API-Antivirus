using Microsoft.AspNetCore.Mvc;
using Api_Antivirus.Services;
using Api_Antivirus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly InstitutionService _institutionService;

        public InstitutionsController(InstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        // 🔹 GET: api/institutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institution>>> GetInstitutions()
        {
            return Ok(await _institutionService.GetAllInstitutionsAsync());
        }

        // 🔹 GET: api/institutions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Institution>> GetInstitution(int id)
        {
            var institution = await _institutionService.GetInstitutionByIdAsync(id);
            if (institution == null)
            {
                return NotFound(new { message = "Institución no encontrada." });
            }
            return Ok(institution);
        }

        // 🔹 POST: api/institutions
        [HttpPost]
        public async Task<ActionResult<Institution>> CreateInstitution(Institution institution)
        {
            var newInstitution = await _institutionService.CreateInstitutionAsync(institution);
            return CreatedAtAction(nameof(GetInstitution), new { id = newInstitution.Id }, newInstitution);
        }

        // 🔹 PUT: api/institutions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstitution(int id, Institution institution)
        {
            var updatedInstitution = await _institutionService.UpdateInstitutionAsync(id, institution);
            if (updatedInstitution == null)
            {
                return NotFound(new { message = "Institución no encontrada." });
            }
            return Ok(updatedInstitution);
        }

        // 🔹 DELETE: api/institutions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitution(int id)
        {
            bool deleted = await _institutionService.DeleteInstitutionAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = "Institución no encontrada." });
            }
            return Ok(new { message = "Institución eliminada correctamente." });
        }
    }
}
