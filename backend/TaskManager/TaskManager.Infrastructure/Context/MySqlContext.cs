using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }



    }
}
