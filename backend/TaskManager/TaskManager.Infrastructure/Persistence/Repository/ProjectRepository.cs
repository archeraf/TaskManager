using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Persistence.Context;
using TaskManager.Infrastructure.Persistence.Repository.Generic;

namespace TaskManager.Infrastructure.Persistence.Repository
{
    internal class ProjectRepository : GenericRepository<Project>
    {
        public ProjectRepository(MySqlContext context) : base(context)
        {
        }
    }
}
