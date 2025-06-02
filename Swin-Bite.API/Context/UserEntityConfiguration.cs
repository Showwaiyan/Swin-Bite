using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasDiscriminator<string>("Type");
            builder
                .HasOne(u => u.BankAccount)
                .WithOne(b => b.User)
                .HasForeignKey<User>(u => u.BankAccountId)
                .IsRequired();
        }
    }
}
