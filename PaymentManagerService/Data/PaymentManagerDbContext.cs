using Microsoft.EntityFrameworkCore;
using PaymentManagerService.Models;

namespace PaymentManagerService.Data
{
    public class PaymentManagerDbContext : DbContext
    {
        public PaymentManagerDbContext(DbContextOptions<PaymentManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().ToTable("Payments");
        }
    }
}
