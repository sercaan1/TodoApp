using Microsoft.EntityFrameworkCore;

namespace TodoListApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem() { Id = 1, Title = "Do your homework", IsDone = true },
                new TodoItem() { Id = 2, Title = "Do fitness", IsDone = false },
                new TodoItem() { Id = 3, Title = "Call your parents", IsDone = false },
                new TodoItem() { Id = 4, Title = "Clean your room", IsDone = true }
                );
        }
    }
}
