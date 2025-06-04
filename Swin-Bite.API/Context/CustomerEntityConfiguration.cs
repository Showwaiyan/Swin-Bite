using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder) { }

        public void Seed(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    UserId = 1,
                    UserType = UserType.Customer,
                    BankAccountId = 100001,
                },
                new Customer
                {
                    UserId = 2,
                    UserType = UserType.Customer,
                    BankAccountId = 100002,
                }
            );
        }
    }
}
