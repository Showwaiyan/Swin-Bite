using Microsoft.EntityFrameworkCore;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          // User
            new UserEntityConfiguration().Configure(modelBuilder.Entity<User>());

            // BankAccount
            new BankAccountEnitiyConfiguration().Configure(modelBuilder.Entity<BankAccount>());
            new BankAccountEnitiyConfiguration().Seed(modelBuilder.Entity<BankAccount>());
        }
    }
}
