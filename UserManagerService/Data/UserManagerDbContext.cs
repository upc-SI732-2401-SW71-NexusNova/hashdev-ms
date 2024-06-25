using Microsoft.EntityFrameworkCore;
using UserManagerService.Models;

namespace UserManagerService.Data
{
    public class UserManagerDbContext : DbContext
    {
        public UserManagerDbContext(DbContextOptions<UserManagerDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);
        }
    }
}
