using TaskManager.Application.DTO.Request;
using TaskManager.Application.DTO.Response;

namespace TaskManager.Application.Services.Contracts
{
    public interface IProjectService
    {
        public Task<bool> ProjectExistsAsync(int projectId);
        public Task<ProjectResponse?> CreateProjectAsync(CreateProjectRequest projectRequest);
        public Task<ProjectResponse?> GetProjectByIdAsync(int projectRequest);
        public Task<IEnumerable<ProjectResponse>> GetAllProjectsAsync();
        public Task<ProjectResponse> UpdateProjectAsync(int projectId, UpdateProjectRequest projectRequest);
        public Task DeleteProjectByIdAsync(int projectId);


    }
}
