using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class ShoppingCartEntityConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            // One-to-One Relationship with Customer
            builder
                .HasOne(s => s.Customer)
                .WithOne(c => c.ShoppingCart)
                .HasForeignKey<ShoppingCart>(s => s.CustomerId)
                .IsRequired();

            // Auto Generated PK
            builder.Property(s => s.ShoppingCartId).ValueGeneratedOnAdd();
        }

        public void Seed(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasData(
                new ShoppingCart { ShoppingCartId = 1, CustomerId = 1 },
                new ShoppingCart { ShoppingCartId = 2, CustomerId = 2 }
            );
        }
    }
}
