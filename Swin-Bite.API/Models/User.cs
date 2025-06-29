using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class User
    {
        // Fields
        private int _userId;
        private string _username;
        private string _email;
        private string _password;
        private bool _isAuthenticated;
        private UserType _userType;
        private int _bankAccountId;
        private string _address;

        private List<Notification> _notifications;

        private BankAccount _bankAccount;

        // Constructor
        public User()
        {
            _notifications = new List<Notification>();
        }

        //Properties
        [Key]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        [Required]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        [EmailAddress]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set { _isAuthenticated = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        // Discriminator
        [Required]
        public UserType UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        // For one-to-one relationship with Bankaccount
        public int BankAccountId
        {
            get { return _bankAccountId; }
            set { _bankAccountId = value; }
        }

        [ForeignKey("BankAccountId")]
        public BankAccount BankAccount
        {
            get { return _bankAccount; }
            set { _bankAccount = value; }
        }

        public List<Notification> Notifications
        {
            get { return _notifications; }
        }

        //Methods
        public bool Login(string password)
        {
            if (!(Password == password))
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

        protected void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications.ToList();
        }
    }
}
