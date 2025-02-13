
using Microsoft.AspNetCore.Mvc;
using Api_Antivirus.Models;
using Api_Antivirus.Services;

namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService= userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetId(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetId), new {id = user.Id}, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] User user)
        {
            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            user.Id = id;
            await _userService.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exitingUser = await _userService.GetByIdAsync(id);
            if (exitingUser == null)
            {
                return NotFound();
            }
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}