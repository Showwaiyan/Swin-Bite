using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasDiscriminator<UserType>(u => u.UserType)
                .HasValue(UserType.Customer)
                .HasValue(UserType.RestaurantOwner)
                .HasValue(UserType.Admin)
                .HasValue(UserType.DeliveryDriver);

            builder
                .HasOne(u => u.BankAccount)
                .WithOne()
                .HasForeignKey<User>(u => u.BankAccountId)
                .IsRequired(false); // Optional for now (development process)
        }
    }
}
