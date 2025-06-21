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
                .HasValue<Dish>(FoodCategory.Dish)
                .HasValue<Drink>(FoodCategory.Drink)
                .HasValue<Snack>(FoodCategory.Snack);

            builder.Property(f=>f.TotalQuantity).HasDefaultValue(0);
        }
    }
}
