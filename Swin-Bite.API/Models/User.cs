using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class User
    {
        // Fields
        private int _id;
        private string _name;
        private string _type;
        private int _bankAccountId;

        private BankAccount _bankAccount; // for one-to-one relation

        // Properties
        [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        
        public int BankAccountId
        {
            get { return _bankAccountId; }
            set { _bankAccountId = value; }
        }

        // Navigation property for one-to-one relation
        [ForeignKey("BankAccountId")]
        public BankAccount BankAccount
        {
            get { return _bankAccount; }
            set { _bankAccount = value; }
        }

        // Discriminator Property
        [Required]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
