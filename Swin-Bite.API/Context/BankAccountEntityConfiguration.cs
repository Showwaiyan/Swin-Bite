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
            builder.Property(b => b.Balance).HasDefaultValue(0);
            builder.Property(b => b.IsActive).HasDefaultValue(true); // Optional for Development
            builder.Property(b => b.Pin).IsRequired();
        }

        public void Seed(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasData(
                new BankAccount
                {
                    BankId = 100001,
                    AccountNumber = "12345678",
                    Balance = 500.00m,
                    Pin = "1234",
                    IsActive = true,
                },
                new BankAccount
                {
                    BankId = 100002,
                    AccountNumber = "87654321",
                    Balance = 300.00m,
                    Pin = "5678",
                    IsActive = true,
                },
                new BankAccount
                {
                    BankId = 100003,
                    AccountNumber = "24681012",
                    Balance = 300.00m,
                    Pin = "4321",
                    IsActive = true,
                },
                new BankAccount
                {
                    BankId = 100004,
                    AccountNumber = "01357911",
                    Balance = 300.00m,
                    Pin = "8765",
                    IsActive = true,
                },
                new BankAccount
                {
                    BankId = 100005,
                    AccountNumber = "02468022",
                    Balance = 500.00m,
                    Pin = "4321",
                    IsActive = true,
                },
                new BankAccount
                {
                    BankId = 100006,
                    AccountNumber = "13579135",
                    Balance = 750.00m,
                    Pin = "9876",
                    IsActive = true,
                }
            );
        }
    }
}
