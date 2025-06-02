using System.ComponentModel.DataAnnotations;

namespace SwinBite.Models
{
    public class BankAccount
    {
        // Fields
        private int _id;
        private string _accountNumber;
        private int _ageRestriction;

        private User _user;

        // Properties
        [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Required]
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        [Required]
        public int AgeRestriction
        {
            get { return _ageRestriction; }
            set {
              if (value < 0) throw new ArgumentException("Age Restriction cannot be negative value");
              _ageRestriction = value;
            }
        }

        // Navigation property for one-to-one relation
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
