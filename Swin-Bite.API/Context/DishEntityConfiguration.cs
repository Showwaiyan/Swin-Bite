using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class DishEntityConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder) { }

        public void Seed(EntityTypeBuilder<Dish> builder)
        {
            builder.HasData(
                new Dish
                {
                    FoodId = 1,
                    Name = "Spicy Noodles",
                    Price = 10.00m,
                    RestaurantId = 3,
                    IsAvailable = true,
                },
                new Dish
                {
                    FoodId = 3,
                    Name = "Grilled Chicken",
                    Price = 12.00m,
                    RestaurantId = 4,
                    IsAvailable = true,
                }
            );
        }
    }
}
