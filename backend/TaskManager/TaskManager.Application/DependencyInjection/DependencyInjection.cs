using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.DTO.Request;
using TaskManager.Application.Services;
using TaskManager.Application.Services.Contracts;
using TaskManager.Application.Validators;

namespace TaskManager.Application.DependencyInjection
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateProjectRequest>();

            service.AddScoped<IValidator<CreateProjectRequest>, CreateProjectRequestValidator>();
            service.AddScoped<IProjectService, ProjectService>();
            return service;
        }
    }
}
