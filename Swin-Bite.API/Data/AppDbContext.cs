using Microsoft.EntityFrameworkCore;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BankAccountEnitiyConfiguration().Configure(modelBuilder.Entity<BankAccount>());
            new UserEntityConfiguration().Configure(modelBuilder.Entity<User>());
        }
    }
}
