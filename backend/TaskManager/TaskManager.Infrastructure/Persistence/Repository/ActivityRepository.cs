using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Persistence.Context;
using TaskManager.Infrastructure.Persistence.Repository.Generic;

namespace TaskManager.Infrastructure.Persistence.Repository
{
    internal class ActivityRepository : GenericRepository<Activity>
    {
        public ActivityRepository(MySqlContext context) : base(context)
        {
        }

    }
}
