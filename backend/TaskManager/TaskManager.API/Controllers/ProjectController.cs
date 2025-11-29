using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = new { Id = id, Name = "Sample Project" };
            return Ok(project);
        }


    }
}
