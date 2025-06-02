using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class BankAccountEntityConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasAlternateKey(e => e.AccountNumber);
            builder.Property(b => b.AgeRestriction).IsRequired().HasDefaultValue(0);
        }

        public void Seed(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasData(
                new BankAccount
                {
                    Id = 100001,
                    AccountNumber = "105293041",
                    AgeRestriction = 18,
                },
                new BankAccount
                {
                    Id = 100002,
                    AccountNumber = "205184732",
                    AgeRestriction = 21,
                },
                new BankAccount
                {
                    Id = 100003,
                    AccountNumber = "305729184",
                    AgeRestriction = 0,
                },
                new BankAccount
                {
                    Id = 100004,
                    AccountNumber = "405318907",
                    AgeRestriction = 16,
                },
                new BankAccount
                {
                    Id = 100005,
                    AccountNumber = "505274193",
                    AgeRestriction = 65,
                }
            );
        }
    }
}
