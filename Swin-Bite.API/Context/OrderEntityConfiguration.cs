using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Many-To-One Relaitonship with Customer
            builder
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            // Many-To-One Relationship with Restaurant
            builder
                .HasOne(o => o.Restaurant)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.RestaurantId);

            // Many-To-Zero Relationship with DeliveryDriver
            builder
                .HasOne(o => o.DeliveryDriver)
                .WithMany(d => d.Deliveries)
                .HasForeignKey(o => o.DeliveryDriverId)
                .IsRequired(false);

            // Auto Generated PK
            builder.Property(o => o.OrderId).ValueGeneratedOnAdd();
        }

        public void Seed(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    OrderId = 1,
                    CustomerId = 1,
                    RestaurantId = 3,
                    TotalPrice = 13.00m,
                    Status = OrderStatus.Pending,
                    OrderDate = DateTime.SpecifyKind(
                        new DateTime(2024, 01, 01, 12, 00, 00),
                        DateTimeKind.Utc
                    ),
                    PickUpTime = DateTime.SpecifyKind(
                        new DateTime(2024, 01, 01, 12, 00, 00),
                        DateTimeKind.Utc
                    ),
                },
                new Order
                {
                    OrderId = 2,
                    CustomerId = 2,
                    RestaurantId = 4,
                    TotalPrice = 14.50m,
                    Status = OrderStatus.Pending,
                    OrderDate = DateTime.SpecifyKind(
                        new DateTime(2024, 01, 01, 12, 00, 00),
                        DateTimeKind.Utc
                    ),
                    PickUpTime = DateTime.SpecifyKind(
                        new DateTime(2024, 01, 01, 12, 00, 00),
                        DateTimeKind.Utc
                    ),
                }
            );
        }
    }
}
