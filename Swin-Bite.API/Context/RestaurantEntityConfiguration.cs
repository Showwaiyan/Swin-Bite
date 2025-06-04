using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

public class RestaurantEntityConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        // One-To-Many Relationship with Food
        builder
            .HasMany(r => r.Menu)
            .WithOne(f => f.Restaurant)
            .HasForeignKey(f => f.RestaurantId)
            .IsRequired();
    }

    public void Seed(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasData(
            new Restaurant
            {
                UserId = 3,
                UserType = UserType.RestaurantOwner,
                BankAccountId = 100003,
            },
            new Restaurant
            {
                UserId = 4,
                UserType = UserType.RestaurantOwner,
                BankAccountId = 100004,
            }
        );
    }
}
