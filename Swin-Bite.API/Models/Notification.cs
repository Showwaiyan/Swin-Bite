using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class Notification
    {
        // Fields
        private int _notificationId;
        private int _userId;
        private User _user;
        private string _message;
        private DateTime _timeStamp;
        private NotificationType _type;
        private bool _isRead;

        // Constructor

        // Properties
        [Key]
        public int NotificationId
        {
            get { return _notificationId; }
            set { _notificationId = value; }
        }

        [Required]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public NotificationType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public bool IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }

        // Many-To-One Relationship
        [Required]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        [ForeignKey("UserId")]
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        // Method
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
