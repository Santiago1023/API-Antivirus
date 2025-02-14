using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api_Antivirus.Models;
using Api_Antivirus.Services;

namespace Api_Antivirus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BootcampTopicsController : ControllerBase
    {
        private readonly IBootcampTopicsService _service;

        public BootcampTopicsController(IBootcampTopicsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBootcampTopics()
        {
            var bootcampTopics = await _service.GetAllBootcampTopicsAsync();
            return Ok(bootcampTopics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBootcampTopicsById(int id)
        {
            var bootcampTopics = await _service.GetBootcampTopicsByIdAsync(id);
            if (bootcampTopics == null)
            {
                return NotFound();
            }
            return Ok(bootcampTopics);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBootcampTopics([FromBody] BootcampTopics bootcampTopics)
        {
            if (bootcampTopics == null)
            {
                return BadRequest();
            }

            var createdBootcampTopics = await _service.CreateBootcampTopicsAsync(bootcampTopics);
            return CreatedAtAction(nameof(GetBootcampTopicsById), new { id = createdBootcampTopics.Id }, createdBootcampTopics);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBootcampTopics(int id, [FromBody] BootcampTopics bootcampTopics)
        {
            if (bootcampTopics == null || bootcampTopics.Id != id)
            {
                return BadRequest();
            }

            var updatedBootcampTopics = await _service.UpdateBootcampTopicsAsync(id, bootcampTopics);
            if (updatedBootcampTopics == null)
            {
                return NotFound();
            }

            return Ok(updatedBootcampTopics);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBootcampTopics(int id)
        {
            var deleted = await _service.DeleteBootcampTopicsAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
