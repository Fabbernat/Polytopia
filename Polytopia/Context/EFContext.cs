using Microsoft.EntityFrameworkCore;

namespace Polytopia.Context
{
    public class EFContext : DbContext
    {
        public DbSet<string> Keys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.//DB//game.db");
        }
    }
}
