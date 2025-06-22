using System.ComponentModel.DataAnnotations;

namespace SwinBite.Models
{
    public class BankAccount
    {
        //Fields
        private int _bankId;
        private string _accountNumber;
        private decimal _balance;
        private string _pin;
        private bool _isActive;
        private User _user;

        // Properties
        [Key]
        public int BankId
        {
            get { return _bankId; }
            set { _bankId = value; }
        }

        [Required]
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        [Required]
        public string Pin
        {
            get { return _pin; }
            set { _pin = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        //Methods
        public bool ProcessPayment(decimal amount)
        {
            return true;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
