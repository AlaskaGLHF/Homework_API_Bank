using Bank.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Data
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BalanceHistory> BalanceHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Card>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.FromCard)
                .WithMany()
                .HasForeignKey(t => t.FromCardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.ToCard)
                .WithMany()
                .HasForeignKey(t => t.ToCardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BalanceHistory>()
                .HasOne(bh => bh.Card)
                .WithMany()
                .HasForeignKey(bh => bh.CardId);
        }
    }
}
