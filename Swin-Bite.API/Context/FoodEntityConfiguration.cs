using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class FoodEntityConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            // Discriminator
            builder
                .HasDiscriminator<FoodCategory>(f => f.Category)
                .HasValue(FoodCategory.Dish)
                .HasValue(FoodCategory.Drink)
                .HasValue(FoodCategory.Snack);
        }
    }
}
