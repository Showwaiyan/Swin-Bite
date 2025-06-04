using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class DrinkEntityConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder) { }

        public void Seed(EntityTypeBuilder<Drink> builder)
        {
            builder.HasData(
                new Drink
                {
                    FoodId = 2,
                    Name = "Iced Tea",
                    Price = 3.00m,
                    RestaurantId = 3,
                    IsAvailable = true,
                },
                new Drink
                {
                    FoodId = 4,
                    Name = "Lemonade",
                    Price = 2.50m,
                    RestaurantId = 4,
                    IsAvailable = true,
                }
            );
        }
    }
}
