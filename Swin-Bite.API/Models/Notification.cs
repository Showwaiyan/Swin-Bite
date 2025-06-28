using System.ComponentModel.DataAnnotations;

namespace SwinBite.Models
{
    public class Notification
    {
        // Fields
        private int _notificationId;
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
