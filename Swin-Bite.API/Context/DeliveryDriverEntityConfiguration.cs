using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class DeliveryDriverEntityConfiguration : IEntityTypeConfiguration<DeliveryDriver>
    {
        public void Configure(EntityTypeBuilder<DeliveryDriver> builder) { }

        public void Seed(EntityTypeBuilder<DeliveryDriver> builder)
        {
            builder.HasData(
                new DeliveryDriver
                {
                    UserId = 5,
                    Username = "John Wick",
                    Password = "johnwikck123",
                    Email = "johnwick@jw.com",
                    UserType = UserType.DeliveryDriver,
                    BankAccountId = 100005,
                },
                new DeliveryDriver
                {
                    UserId = 6,
                    Username = "SkyWalker",
                    Password = "skywalker321",
                    Email = "skywalker@starwar.com",
                    UserType = UserType.DeliveryDriver,
                    BankAccountId = 100006,
                }
            );
        }
    }
}
