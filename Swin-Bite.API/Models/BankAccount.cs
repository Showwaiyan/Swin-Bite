using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int AgeRestriction { get; set; }
    }
}
