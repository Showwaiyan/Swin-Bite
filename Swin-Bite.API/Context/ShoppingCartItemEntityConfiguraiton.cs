using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class ShoppingCartItemEntityConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            // Many-To-One Relationship with ShoppingCart
            builder
                .HasOne(si => si.ShoppingCart)
                .WithMany(s => s.ShoppingCartItems)
                .HasForeignKey(si => si.ShoppingCartId);

            // One-To-One Relationship with Food
            builder.HasOne(si => si.Food).WithMany().HasForeignKey(si => si.FoodId);
        }

        public void Seed(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.HasData(
                new ShoppingCartItem
                {
                    ShoppingCartItemId = 1,
                    ShoppingCartId = 1,
                    FoodId = 1,
                    Quantity = 2,
                },
                new ShoppingCartItem
                {
                    ShoppingCartItemId = 2,
                    ShoppingCartId = 2,
                    FoodId = 2,
                    Quantity = 1,
                }
            );
        }
    }
}
