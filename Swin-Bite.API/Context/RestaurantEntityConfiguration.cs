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
                Username = "Walter White",
                Name = "ChemistryChad",
                Password = "lethimcook",
                Email = "walterwhite@breakingbad.com",
                UserType = UserType.Restaurant,
                BankAccountId = 100003,
            },
            new Restaurant
            {
                UserId = 4,
                Username = "Dean Winchester",
                Name = "ApplePi",
                Password = "iambatman",
                Email = "dean@supernatural.com",
                UserType = UserType.Restaurant,
                BankAccountId = 100004,
            }
        );
    }
}
