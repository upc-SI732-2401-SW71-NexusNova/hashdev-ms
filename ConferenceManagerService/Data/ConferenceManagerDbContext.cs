using ConferenceManagerService.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceManagerService.Data
{
    public class ConferenceManagerDbContext : DbContext
    {
        public ConferenceManagerDbContext(DbContextOptions<ConferenceManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Conference> Conferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conference>().ToTable("Conferences");
        }
    }
}
