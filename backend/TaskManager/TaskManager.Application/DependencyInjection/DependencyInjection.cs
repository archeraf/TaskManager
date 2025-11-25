using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.DTO.MapperProfile;
using TaskManager.Application.DTO.Request;

namespace TaskManager.Application.DependencyInjection
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateProjectRequest>();
            service.AddAutoMapper(typeof(MapperProfile).Assembly);
            return service;
        }
    }
}
