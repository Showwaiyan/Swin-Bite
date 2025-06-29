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
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        // Food and its child classes
        public DbSet<Food> Foods { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Snack> Snacks { get; set; }

        // ShoppingCart
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        // Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // Notification
        public DbSet<Notification> Notifications { get; set; }

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

            new DeliveryDriverEntityConfiguration().Seed(modelBuilder.Entity<DeliveryDriver>());

            // BankAccount
            BankAccountEntityConfiguration BankAccountsEC = new BankAccountEntityConfiguration();
            BankAccountsEC.Configure(modelBuilder.Entity<BankAccount>());
            BankAccountsEC.Seed(modelBuilder.Entity<BankAccount>());

            // Shopping Cart
            ShoppingCartEntityConfiguration ShoppingCartsEC = new ShoppingCartEntityConfiguration();
            ShoppingCartsEC.Configure(modelBuilder.Entity<ShoppingCart>());
            ShoppingCartsEC.Seed(modelBuilder.Entity<ShoppingCart>());

            ShoppingCartItemEntityConfiguration ShoppingCartItemEC =
                new ShoppingCartItemEntityConfiguration();
            ShoppingCartItemEC.Configure(modelBuilder.Entity<ShoppingCartItem>());
            // ShoppingCartItemEC.Seed(modelBuilder.Entity<ShoppingCartItem>());

            // Order
            OrderEntityConfiguration OrderEC = new OrderEntityConfiguration();
            OrderEC.Configure(modelBuilder.Entity<Order>());
            // OrderEC.Seed(modelBuilder.Entity<Order>());
            OrderItemEntityConfiguration OrderItemEC = new OrderItemEntityConfiguration();
            OrderItemEC.Configure(modelBuilder.Entity<OrderItem>());
            // OrderItemEC.Seed(modelBuilder.Entity<OrderItem>());

            // Food
            FoodEntityConfiguration FoodsEC = new FoodEntityConfiguration();
            FoodsEC.Configure(modelBuilder.Entity<Food>());
            // new DishEntityConfiguration().Seed(modelBuilder.Entity<Dish>());
            // new DrinkEntityConfiguration().Seed(modelBuilder.Entity<Drink>());

            // Notification
            new NotificationEntityConfiguration().Configure(modelBuilder.Entity<Notification>());
        }
    }
}
