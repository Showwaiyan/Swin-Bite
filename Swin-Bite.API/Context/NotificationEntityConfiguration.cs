using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwinBite.Models;

namespace SwinBite.Context
{
    public class NotificationEntityConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Many-To-One Relaitonship with Customer
            builder
                .HasOne(n => n.User)
                .WithMany(n => n.Notifications)
                .HasForeignKey(n => n.UserId);

            // Auto Generated PK
            builder.Property(n => n.NotificationId).ValueGeneratedOnAdd();
        }
    }
}
