using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Services.Db
{
    public class TodoListDbContext : DbContext
    {
        public DbSet<TodoListEntity> TodoList { get; set; }

        public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
            : base(options)
        {
        }
    }
}
