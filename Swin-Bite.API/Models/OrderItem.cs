using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class OrderItem
    {
        // Fields
        private int _orderItemId;
        private int _orderId;
        private Order _order;
        private int _foodId;
        private Food _food;
        private int _quantity;
        private decimal _priceAtTime;

        // Properties
        [Key]
        public int OrderItemId
        {
            get { return _orderItemId; }
            set { _orderItemId = value; }
        }

        // Many-To-One Relationship
        [Required]
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        [ForeignKey("OrderId")]
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }

        // Many-To-One Relationship
        [Required]
        public int FoodId
        {
            get { return _foodId; }
            set { _foodId = value; }
        }
        [ForeignKey("FoodId")]
        public Food Food
        {
            get { return _food; }
            set { _food = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal PriceAtTime // To store Food.Price at order time
        {
            get { return _priceAtTime; }
            set { _priceAtTime = value; }
        }

        // Methods
    }
}
