using System.ComponentModel.DataAnnotations;

namespace SwinBite.Models
{
    public class BankAccount
    {
        // Fields
        private int _id;
        private string _accountNumber;
        private int _ageRestriction;

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
            set { _ageRestriction = value; }
        }
    }
}
