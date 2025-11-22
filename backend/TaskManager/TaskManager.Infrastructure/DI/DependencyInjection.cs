namespace TaskManager.Infrastructure.DI
{
    internal class DependencyInjection
    {
        public DependencyInjection() { }

        public IServiceProvider AddInfrastructure(IServiceProvider service)
        {
            return service;
        }
    }
}
