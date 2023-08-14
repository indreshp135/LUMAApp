using Microsoft.EntityFrameworkCore;

namespace LUMAApp.Entities
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base()
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WINDOWS-BVQNF6J;Initial Catalog=LUMA;Integrated Security=True; Encrypt=False");
        }
    }
}
