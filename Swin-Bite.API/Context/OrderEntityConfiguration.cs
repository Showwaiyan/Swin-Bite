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
                    OrderDate = DateTime.UtcNow,
                    PickUpTime = DateTime.UtcNow.AddHours(1),
                },
                new Order
                {
                    OrderId = 2,
                    CustomerId = 2,
                    RestaurantId = 4,
                    TotalPrice = 14.50m,
                    Status = OrderStatus.Pending,
                    OrderDate = DateTime.UtcNow,
                    PickUpTime = DateTime.UtcNow.AddHours(1),
                }
            );
        }
    }
}
