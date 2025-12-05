using AutoMapper;
using System.Linq.Expressions;
using TaskManager.Application.DTO.Request;
using TaskManager.Application.DTO.Response;
using TaskManager.Application.Services.Contracts;
using TaskManager.Domain.Contracts.Generic;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    internal class ProjectService : IProjectService
    {

        private readonly IGenericRepository<Project> _repository;
        private readonly IMapper _mapper;
        private Expression<Func<Project, object>> _includeActivities = project => project.Activities;


        public ProjectService(IGenericRepository<Project> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProjectResponse>> GetAllProjectsAsync()
        {
            var projects = await _repository.GetAllAsync(_includeActivities);
            return _mapper.Map<IEnumerable<ProjectResponse>>(projects);
        }

        public async Task<ProjectResponse?> GetProjectByIdAsync(int projectId)
        {
            if (projectId == 0) throw new ArgumentException("Invalid project ID.", nameof(projectId));


            var project = await _repository.GetByIdAsync(projectId, _includeActivities);

            return project == null ? null : _mapper.Map<ProjectResponse>(project);

        }

        public async Task<ProjectResponse?> CreateProjectAsync(CreateProjectRequest projectRequest)
        {
            if (projectRequest == null)
            {
                throw new ArgumentNullException(nameof(projectRequest), "Project can't be null!");
            }

            var project = _mapper.Map<Project>(projectRequest);

            await _repository.AddAsync(project);

            if (await _repository.SaveChangesAsync())
            {
                return _mapper.Map<ProjectResponse>(project);
            }

            throw new Exception("Failed to create project.");
        }

        public async Task DeleteProjectByIdAsync(int projectId)
        {
            if (projectId == 0) throw new ArgumentException("Invalid project ID.", nameof(projectId));

            await _repository.DeleteByIdAsync(projectId);
        }


        public async Task<bool> ProjectExistsAsync(int projectId)
        {
            if (projectId == 0) throw new ArgumentException("Invalid project ID.", nameof(projectId));

            return await _repository.ExistsAsync(projectId);
        }

        public async Task<ProjectResponse> UpdateProjectAsync(int projectId, UpdateProjectRequest projectRequest)
        {
            if (projectRequest == null)
            {
                throw new ArgumentNullException(nameof(projectRequest), "Project can't be null!");
            }
            var project = _mapper.Map<Project>(projectRequest);
            var updatedProject = await _repository.UpdateAsync(projectId, project);

            return _mapper.Map<ProjectResponse>(updatedProject);

        }
    }
}
