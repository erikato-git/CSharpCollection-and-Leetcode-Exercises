using IEnumerable_ICollection_IList.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Todo> Todos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>().HasData(
                new Todo { Id = 1, Item = "Tomato" },
                new Todo { Id = 2, Item = "Onion" },
                new Todo { Id = 3, Item = "Rice" },
                new Todo { Id = 4, Item = "Cucumber" },
                new Todo { Id = 5, Item = "Cheese" }
            );
        }

    }
}
