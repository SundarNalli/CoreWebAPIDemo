using CoreWebAPIDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPIDemo.Data
{
    public class MyTaskContext : DbContext
    {
        public MyTaskContext(DbContextOptions<MyTaskContext> options) : base(options)
        {
        }

        public DbSet<MyTask> Tasks { get; set; }
    }
}
