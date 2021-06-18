using Microsoft.EntityFrameworkCore;

namespace CicklumTask.Model
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
