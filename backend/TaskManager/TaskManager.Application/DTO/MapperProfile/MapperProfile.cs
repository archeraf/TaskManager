using AutoMapper;
using TaskManager.Application.DTO.Request;
using TaskManager.Application.DTO.Response;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.DTO.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<CreateProjectRequest, Project>();
            CreateMap<Project, ProjectResponse>();
        }

    }
}
