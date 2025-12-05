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
            //Create Project
            CreateMap<CreateProjectRequest, Project>();

            //Update Project
            CreateMap<UpdateProjectRequest, Project>()
                .ForMember(dest => dest.Status,
               opt => opt.MapFrom(src => src.Status)); ;

            //Project Reponse
            CreateMap<Project, ProjectResponse>()
                .ConstructUsing(src => new ProjectResponse(
                    src.Id,
                    src.Title,
                    src.Status.ToString(),
                    src.Description,
                    src.Activities.Select(a => a.Id).ToArray()));

            //Activity Reponse
            CreateMap<Activity, ActivityResponse>();
        }

    }
}
