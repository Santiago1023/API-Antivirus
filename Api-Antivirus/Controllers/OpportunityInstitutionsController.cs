using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Antivirus.Data;
using Api_Antivirus.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunityInstitutionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        

        public OpportunityInstitutionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OpportunityInstitutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpportunityInstitution>>> GetOpportunityInstitutions()
        {
            return await _context.OpportunityInstitutions
                                 .Include(oi => oi.Opportunity)
                                 .Include(oi => oi.Institution)
                                 .ToListAsync();
        }

        // GET: api/OpportunityInstitutions/
        [HttpGet("{id}")]
        public async Task<ActionResult<OpportunityInstitution>> GetOpportunityInstitution(int id)
        {
            var opportunityInstitution = await _context.OpportunityInstitutions
                                                        .Include(oi => oi.Opportunity)
                                                        .Include(oi => oi.Institution)
                                                        .FirstOrDefaultAsync(oi => oi.Id == id);

            if (opportunityInstitution == null)
            {
                return NotFound();
            }

            return opportunityInstitution;
        }

        // POST: api/OpportunityInstitutions
        [HttpPost]
        public async Task<ActionResult<OpportunityInstitution>> PostOpportunityInstitution(OpportunityInstitution opportunityInstitution)
        {
            _context.OpportunityInstitutions.Add(opportunityInstitution);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOpportunityInstitution), new { id = opportunityInstitution.Id }, opportunityInstitution);
        }

        // PUT: api/OpportunityInstitutions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpportunityInstitution(int id, OpportunityInstitution opportunityInstitution)
        {
            if (id != opportunityInstitution.Id)
            {
                return BadRequest();
            }

            _context.Entry(opportunityInstitution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.OpportunityInstitutions.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/OpportunityInstitutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpportunityInstitution(int id)
        {
            var opportunityInstitution = await _context.OpportunityInstitutions.FindAsync(id);
            if (opportunityInstitution == null)
            {
                return NotFound();
            }

            _context.OpportunityInstitutions.Remove(opportunityInstitution);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
