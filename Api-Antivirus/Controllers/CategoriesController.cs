using Microsoft.AspNetCore.Mvc;
using Api_Antivirus.Services;
using Api_Antivirus.Models;


namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categorySercice;

        public CategoriesController (ICategoryService categoryService)
        {
            _categorySercice = categoryService;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<Category>>> GetAll ()
        {
            return Ok(await _categorySercice.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Category>> GetId (int Id)
        {
            var category = await _categorySercice.GetByIdAsync(Id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create ([FromBody] Category category)
        {
            if(category == null)
            {
                return BadRequest("Los datos no pueden ser Nulos.");
            }

            try
            {
                await _categorySercice.CreateAsync(category);
                return CreatedAtAction(nameof(Create), new{ id = category.Id}, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Category category)
        {
            var existingCategory = await _categorySercice.GetByIdAsync(id);
            if (existingCategory != null)
            {
                category.Id = id;
                await _categorySercice.UpdateAsync(category);
                return NoContent();
            }
            return NotFound();
            
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var existingCategory = await _categorySercice.GetByIdAsync(id);
            if (existingCategory != null)
            {
                await _categorySercice.DeleteAsync(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}