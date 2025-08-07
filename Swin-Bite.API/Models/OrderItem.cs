using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        // Many-To-One Relationship with Order
        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        // Many-To-One Relationship with Food
        [Required]
        public int FoodId { get; set; }

        [ForeignKey("FoodId")]
        public Food Food { get; set; }

        public int Quantity { get; set; }

        // Price of the food at the time the order was placed
        public decimal PriceAtTime { get; set; }
    }
}

