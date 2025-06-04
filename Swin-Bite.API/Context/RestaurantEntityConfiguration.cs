using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

public class RestaurantEntityConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        // One-To-Many Relationship with Food
        builder.HasMany(r => r.Menu).WithOne(f => f.Restaurant).IsRequired();
    }
}
