using Microsoft.AspNetCore.Mvc;
using Api_Antivirus.Services;
using Api_Antivirus.Models;
using Api_Antivirus.Dto;

namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetAll()
        {
            return Ok(await _topicService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> Get(int id)
        {
            var topic = await _topicService.GetByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TopicDto topic)
        {
            await _topicService.CreateAsync(topic);
            return CreatedAtAction(nameof(Get),topic);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TopicDto topic)
        {
            var existingTopic=await _topicService.GetByIdAsync(id);
            if (existingTopic==null) 
            {
                return NotFound();
            }
            await _topicService.UpdateAsync(id, topic);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id) 
        {
            var existingTopic=await _topicService.GetByIdAsync(id);
            if (existingTopic==null)
            {
                return NotFound();
            }
            await _topicService.DeleteAsync(id);
            return NoContent();
        }


    }
}