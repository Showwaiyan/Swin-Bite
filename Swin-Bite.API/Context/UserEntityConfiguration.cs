using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Discriminator
            builder
                .HasDiscriminator<UserType>(u => u.UserType)
                .HasValue<Customer>(UserType.Customer)
                .HasValue<Restaurant>(UserType.RestaurantOwner)
                .HasValue(UserType.Admin)
                .HasValue(UserType.DeliveryDriver);

            // One-To-One Relationship with BankAccount
            builder
                .HasOne(u => u.BankAccount)
                .WithOne(b => b.User)
                .HasForeignKey<User>(u => u.BankAccountId)
                .IsRequired(false); // Optional for now (development process)

            // Unique Properties set
            builder.HasIndex(u=>u.Username).IsUnique();
            builder.HasIndex(u=>u.Email).IsUnique();
        }
    }
}
