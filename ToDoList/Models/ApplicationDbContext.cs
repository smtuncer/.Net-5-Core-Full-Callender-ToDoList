using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-RD7402J8;Database=ToDoListDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Events> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Not> Nots { get; set; }
    }
}
