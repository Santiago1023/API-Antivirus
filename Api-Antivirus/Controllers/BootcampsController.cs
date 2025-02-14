using Microsoft.AspNetCore.Mvc;
using Api_Antivirus.Services;
using Api_Antivirus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampsController : ControllerBase
    {
        private readonly BootcampService _bootcampService;

        public BootcampsController(BootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        // 🔹 GET: api/bootcamps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bootcamp>>> GetBootcamps()
        {
            return Ok(await _bootcampService.GetAllBootcampsAsync());
        }

        // 🔹 GET: api/bootcamps/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Bootcamp>> GetBootcamp(int id)
        {
            var bootcamp = await _bootcampService.GetBootcampByIdAsync(id);
            if (bootcamp == null)
            {
                return NotFound(new { message = "Bootcamp no encontrado." });
            }
            return Ok(bootcamp);
        }

        // 🔹 POST: api/bootcamps
        [HttpPost]
        public async Task<ActionResult<Bootcamp>> CreateBootcamp(Bootcamp bootcamp)
        {
            var newBootcamp = await _bootcampService.CreateBootcampAsync(bootcamp);
            return CreatedAtAction(nameof(GetBootcamp), new { id = newBootcamp.Id }, newBootcamp);
        }

        // 🔹 PUT: api/bootcamps/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBootcamp(int id, Bootcamp bootcamp)
        {
            var updatedBootcamp = await _bootcampService.UpdateBootcampAsync(id, bootcamp);
            if (updatedBootcamp == null)
            {
                return NotFound(new { message = "Bootcamp no encontrado." });
            }
            return Ok(updatedBootcamp);
        }

        // 🔹 DELETE: api/bootcamps/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBootcamp(int id)
        {
            bool deleted = await _bootcampService.DeleteBootcampAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = "Bootcamp no encontrado." });
            }
            return Ok(new { message = "Bootcamp eliminado correctamente." });
        }
    }
}
