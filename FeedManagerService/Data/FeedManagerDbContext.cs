using FeedManagerService.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedManagerService.Data
{
    public class FeedManagerDbContext : DbContext
    {
        public FeedManagerDbContext(DbContextOptions<FeedManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .HasForeignKey(c => c.UserId);
        }
    }
}
