using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Services.Db
{
    public class TodoListDbContext : DbContext
    {
        public DbSet<TodoListEntity> Entities { get; set; }

        public TodoListDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
