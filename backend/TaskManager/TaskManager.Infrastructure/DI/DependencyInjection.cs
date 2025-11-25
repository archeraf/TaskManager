using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Contracts.Generic;
using TaskManager.Infrastructure.Persistence.Repository.Generic;

namespace TaskManager.Infrastructure.DI
{
    internal class DependencyInjection
    {
        public DependencyInjection() { }

        public IServiceCollection AddInfrastructure(IServiceCollection service)
        {
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return service;
        }
    }
}
