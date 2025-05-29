using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("BankAccount")]
        public string BankAccountId { get; set; }

        // Discriminator Property
        public string Type { get; set; }
    }
}
