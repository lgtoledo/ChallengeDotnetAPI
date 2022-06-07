using ChallengeDotnetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeDotnetAPI.Data
{
    public class DisneyContext : DbContext
    {
        public DisneyContext(DbContextOptions<DisneyContext> options) : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasKey(c => c.ID);
            modelBuilder.Entity<Genre>().HasKey(g => g.ID);
            modelBuilder.Entity<Movie>().HasKey(m => m.ID);
        }
    }
}
