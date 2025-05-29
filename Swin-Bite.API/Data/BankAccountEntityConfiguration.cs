using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class BankAccountEnitiyConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasAlternateKey(e => e.AccountNumber);
        }

        public void Seed(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasData(
                new BankAccount
                {
                    Id = 123456,
                    AccountNumber = "105293041",
                    AgeRestriction = 18,
                }
            );
        }
    }
}
