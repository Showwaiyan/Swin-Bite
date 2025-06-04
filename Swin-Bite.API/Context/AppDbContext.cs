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
        public DbSet<Dish> Dishs { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Snack> Snacks { get; set; }

        // ShoppingCart
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            new UserEntityConfiguration().Configure(modelBuilder.Entity<User>());

            new CustomerEntityConfiguration().Seed(modelBuilder.Entity<Customer>());

            RestaurantEntityConfiguration RestaurantsEC = new RestaurantEntityConfiguration();
            RestaurantsEC.Configure(modelBuilder.Entity<Restaurant>());
            RestaurantsEC.Seed(modelBuilder.Entity<Restaurant>());

            // BankAccount
            BankAccountEntityConfiguration BankAccountsEC = new BankAccountEntityConfiguration();
            BankAccountsEC.Configure(modelBuilder.Entity<BankAccount>());
            BankAccountsEC.Seed(modelBuilder.Entity<BankAccount>());

            // Shopping Cart
            ShoppingCartEntityConfiguration ShoppingCartsEC = new ShoppingCartEntityConfiguration();
            ShoppingCartsEC.Configure(modelBuilder.Entity<ShoppingCart>());
            ShoppingCartsEC.Seed(modelBuilder.Entity<ShoppingCart>());

            new ShoppingCartItemEntityConfiguration().Configure(
                modelBuilder.Entity<ShoppingCartItem>()
            );

            // Food
            FoodEntityConfiguration FoodsEC = new FoodEntityConfiguration();
            FoodsEC.Configure(modelBuilder.Entity<Food>());
            new DishEntityConfiguration().Seed(modelBuilder.Entity<Dish>());
            new DrinkEntityConfiguration().Seed(modelBuilder.Entity<Drink>());
        }
    }
}
