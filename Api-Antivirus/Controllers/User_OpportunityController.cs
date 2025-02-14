
using Api_Antivirus.Models;
using Api_Antivirus.Services;
using Microsoft.AspNetCore.Mvc;


namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_OpportunityController : ControllerBase
    {
        private readonly IUser_OpportunityService _user_OpportunityService;

        public User_OpportunityController(IUser_OpportunityService userOpportunityService)
        {
            _user_OpportunityService = userOpportunityService;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<User_Opportunity>>> GetAll ()
        {
            return Ok(await _user_OpportunityService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<User_Opportunity>> GetId (int Id)
        {
            var userOpportunity = await _user_OpportunityService.GetByIdAsync(Id);
            if (userOpportunity != null)
            {
                return Ok(userOpportunity);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create ([FromBody] User_Opportunity user_Opportunity)
        {
            if(user_Opportunity == null)
            {
                return BadRequest("Los datos no pueden ser Nulos.");
            }

            try
            {
                await _user_OpportunityService.CreateAsync(user_Opportunity);
                return CreatedAtAction(nameof(Create), new{ id = user_Opportunity.Id}, user_Opportunity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, User_Opportunity user_Opportunity)
        {
            var existingUserOpportunity = await _user_OpportunityService.GetByIdAsync(id);
            if (existingUserOpportunity != null)
            {
                user_Opportunity.Id = id;
                await _user_OpportunityService.UpdateAsync(user_Opportunity);
                return NoContent();
            }
            return NotFound();
            
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var existingUserOpportu = await _user_OpportunityService.GetByIdAsync(id);
            if (existingUserOpportu != null)
            {
                await _user_OpportunityService.DeleteAsync(id);
                return NoContent();
            }
            return NotFound();
        }   
    }
}