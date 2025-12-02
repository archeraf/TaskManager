using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTO.Request;
using TaskManager.Application.Services.Contracts;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                var projects = await _projectService.GetAllProjectsAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                throw new Exception("Error when trying to retrieve projects", ex.InnerException);
            }
        }

        [HttpGet("getProjectById")]
        public async Task<IActionResult> GetProjectById([FromQuery] int id)
        {
            try
            {
                var project = await _projectService.GetProjectByIdAsync(id);
                return Ok(project);
            }
            catch (Exception ex)
            {

                throw new Exception("Error on project search!", ex.InnerException);
            }
        }

        [HttpGet("exists")]
        public async Task<IActionResult> ProjectExists([FromQuery] int id)
        {
            try
            {
                var exists = await _projectService.ProjectExistsAsync(id);
                return Ok(exists);
            }
            catch (Exception ex)
            {
                throw new Exception("Error when checking if project exists!", ex.InnerException);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest projectRequest)
        {
            try
            {
                var createdProject = await _projectService.CreateProjectAsync(projectRequest);
                return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Id }, createdProject);
            }
            catch (Exception ex)
            {
                throw new Exception("Error when trying to create project!", ex.InnerException);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectRequest projectRequest)
        {
            try
            {
                var updatedProject = await _projectService.UpdateProjectAsync(projectRequest.Id, projectRequest);
                return Ok(updatedProject);
            }
            catch (Exception ex)
            {
                throw new Exception("Error when trying to update project!", ex.InnerException);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject([FromQuery] int id)
        {
            try
            {
                await _projectService.DeleteProjectByIdAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception("Error when trying to delete project!", ex.InnerException);
            }
        }

    }
}
