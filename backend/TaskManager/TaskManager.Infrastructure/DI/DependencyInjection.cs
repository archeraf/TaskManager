using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Contracts.Generic;
using TaskManager.Infrastructure.Persistence.Repository.Generic;

namespace TaskManager.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return service;
        }
    }
}
