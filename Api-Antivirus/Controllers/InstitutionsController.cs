using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Antivirus.Data; // Asegúrate de que este namespace es el correcto
using Api_Antivirus.Models;

namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstitutionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/institutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<institution>>> GetInstitutions()
        {
            return await _context.institutions.ToListAsync();
        }

        // GET: api/institutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<institution>> GetInstitution(int id)
        {
            var institution = await _context.institutions.FindAsync(id);
            if (institution == null)
                return NotFound();

            return institution;
        }

        // POST: api/institutions
        [HttpPost]
        public async Task<ActionResult<institution>> PostInstitution(institution institution)
        {
            _context.institutions.Add(institution);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInstitution), new { id = institution.id }, institution);
        }

        // PUT: api/institutions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitution(int id, institution institution)
        {
            if (id != institution.id)
                return BadRequest();

            _context.Entry(institution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.institutions.Any(e => e.id == id))
                    return NotFound();
                else
                    throw;
            }

            return Ok(institution);
        }

        // DELETE: api/institutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitution(int id)
        {
            var institution = await _context.institutions.FindAsync(id);
            if (institution == null)
                return NotFound();

            _context.institutions.Remove(institution);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
