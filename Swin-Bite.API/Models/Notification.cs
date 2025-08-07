using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime TimeStamp { get; set; }

        public NotificationType Type { get; set; }

        public bool IsRead { get; set; }

        // Many-To-One Relationship
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        // Methods
        public void MarkAsRead()
        {
            IsRead = true;
        }

        public string GetContent()
        {
            return $"[{Type}] {Message} - {TimeStamp:yyyy-MM-dd HH:mm}";
        }
    }
}
