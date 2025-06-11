using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Many-To-One Relationship with Order
            builder
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            // Many-To-One Relationship with Food
            builder.HasOne(oi => oi.Food).WithMany().HasForeignKey(oi => oi.FoodId);

            // Auto Generated PK
            builder.Property(oi=>oi.OrderItemId).ValueGeneratedOnAdd();
        }

        public void Seed(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasData(
                new OrderItem
                {
                    OrderItemId = 1,
                    OrderId = 1,
                    FoodId = 1, // Spicy Noodles
                    Quantity = 1,
                    PriceAtTime = 10.00m,
                },
                new OrderItem
                {
                    OrderItemId = 2,
                    OrderId = 1,
                    FoodId = 2, // Iced Tea
                    Quantity = 1,
                    PriceAtTime = 3.00m,
                },
                new OrderItem
                {
                    OrderItemId = 3,
                    OrderId = 2,
                    FoodId = 3, // Grilled Chicken
                    Quantity = 1,
                    PriceAtTime = 12.00m,
                },
                new OrderItem
                {
                    OrderItemId = 4,
                    OrderId = 2,
                    FoodId = 4, // Lemonade
                    Quantity = 1,
                    PriceAtTime = 2.50m,
                }
            );
        }
    }
}
