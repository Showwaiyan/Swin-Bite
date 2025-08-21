using System.ComponentModel.DataAnnotations;

namespace SwinBite.Models
{
    public class User
    {
        // Constructor
        public User()
        {
            Notifications = new List<Notification>();
        }

        // Properties
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Address { get; set; }

        [Required]
        public UserType UserType { get; set; }

        // Navigation property with private setter to control collection access
        public List<Notification> Notifications { get; private set; }

        // Methods
        public bool Login(string password)
        {
            if (Password != password)
                return false;
            IsAuthenticated = true;
            return true;
        }

        public void Logout()
        {
            IsAuthenticated = false;
        }

        public void UpdateProfile(User user)
        {
            Username = user.Username;
            Email = user.Email;
        }

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return Notifications.ToList();
        }
    }
}

