using System.ComponentModel.DataAnnotations;

namespace SwinBite.Models
{
    public class BankAccount
    {
        // Properties
        [Key]
        public int BankId { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        [Required]
        public string Pin { get; set; }

        public bool IsActive { get; set; }

        public User User { get; set; }

        //Methods
        public void ProcessPayment(decimal amount)
        {
            Balance += amount;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
