using Microsoft.EntityFrameworkCore;

namespace CiklumTasks.Model
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
    }
}
