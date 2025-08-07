using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }

        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; }

        [Required]
        public int FoodId { get; set; }

        [ForeignKey("FoodId")]
        public Food Food { get; set; }
    }
}
