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

            // One-to-Many Relationship with Food
            builder.HasMany(s => s.Items).WithOne().IsRequired(false);
        }
    }
}
