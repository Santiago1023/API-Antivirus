using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api_Antivirus.Models;
using Api_Antivirus.Services;
 
namespace Api_Antivirus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstitutionBootcampsController : ControllerBase
    {
        private readonly IInstitutionBootcampService _service;
 
        public InstitutionBootcampsController(IInstitutionBootcampService service)
        {
            _service = service;
        }
 
        [HttpGet]
        public async Task<IActionResult> GetAllInstitutionBootcamps()
        {
            var institutionBootcamps = await _service.GetAllInstitutionBootcampsAsync();
            return Ok(institutionBootcamps);
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstitutionBootcampById(int id)
        {
            var institutionBootcamp = await _service.GetInstitutionBootcampByIdAsync(id);
            if (institutionBootcamp == null) return NotFound();
            return Ok(institutionBootcamp);
        }
 
        [HttpPost]
        public async Task<IActionResult> CreateInstitutionBootcamp(InstitutionBootcamp institutionBootcamp)
        {
            var createdInstitutionBootcamp = await _service.CreateInstitutionBootcampAsync(institutionBootcamp);
            return CreatedAtAction(nameof(GetInstitutionBootcampById), new { id = createdInstitutionBootcamp.Id }, createdInstitutionBootcamp);
        }
 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstitutionBootcamp(int id, InstitutionBootcamp institutionBootcamp)
        {
            var updatedBootcamp = await _service.UpdateInstitutionBootcampAsync(id, institutionBootcamp);
            if (updatedBootcamp == null) return NotFound();
            return Ok(updatedBootcamp);
        }
    }
}


