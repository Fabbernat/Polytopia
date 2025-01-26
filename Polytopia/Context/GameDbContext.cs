using Microsoft.EntityFrameworkCore;
using Polytopia.Models;
namespace Polytopia.Context
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options)
                   : base(options)
        {
        }

        public DbSet<HighScoreEntry> HighScores { get; set; }
    }
}
