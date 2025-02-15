using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpportunitiesAPI.Services;
using OpportunitiesAPI.Models;

namespace OpportunitiesAPI.Controllers
using Api_Antivirus.Controllers;
using Api_Antivirus.Services;
using Api_Antivirus.Models;



//namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class OpportunitiesController : ControllerBase
    {
        private readonly IOpportunityService _opportunityService;

        public OpportunitiesController(IOpportunityService opportunityService)
        {
            _opportunityService = opportunityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var opportunities = await _opportunityService.GetAllAsync();
            return Ok(opportunities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var opportunity = await _opportunityService.GetByIdAsync(id);
            if (opportunity == null) return NotFound("Oportunidad no encontrada.");
            return Ok(opportunity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Opportunity opportunity)
        {
            if (!ModelState.IsValid) return BadRequest("Los datos proporcionados no son válidos.");

            var createdOpportunity = await _opportunityService.CreateAsync(opportunity);
            return CreatedAtAction(nameof(GetById), new { id = createdOpportunity.Id }, createdOpportunity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Opportunity opportunity)
        {
            if (id != opportunity.Id) return BadRequest("El ID de la URL no coincide con el ID de la oportunidad.");

            var success = await _opportunityService.UpdateAsync(opportunity);
            if (!success) return NotFound("No se pudo actualizar la oportunidad. Puede que no exista.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _opportunityService.DeleteAsync(id);
            if (!success) return NotFound("No se pudo eliminar la oportunidad. Puede que no exista.");

            return NoContent();
        }
    }
}
