using Microsoft.EntityFrameworkCore;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class AppDbContext : DbContext
    {
        // User and its child classes
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        // Food and its child classes
        public DbSet<Food> Foods { get; set; }
        public DbSet<Dish> Dishs {get; set;}
        public DbSet<Drink> Drinks {get; set;}
        public DbSet<Snack> Snacks {get; set;}

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            new UserEntityConfiguration().Configure(modelBuilder.Entity<User>());

            // BankAccount
            new BankAccountEntityConfiguration().Configure(modelBuilder.Entity<BankAccount>());
            new BankAccountEntityConfiguration().Seed(modelBuilder.Entity<BankAccount>());

            // Shopping Cart
            new ShoppingCartEntityConfiguration().Configure(modelBuilder.Entity<ShoppingCart>());
        }
    }
}
