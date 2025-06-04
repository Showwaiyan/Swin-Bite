using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class ShoppingCart
    {
        // Fields
        private int _shoppingCartId;
        private int _customerId;
        private Customer _customer;
        private List<ShoppingCartItem> _shoppingCartItem;

        // Properties
        [Key]
        public int ShoppingCartId
        {
            get { return _shoppingCartId; }
            set { _shoppingCartId = value; }
        }

        public List<ShoppingCartItem> ShoppingCartItem
        {
            get { return _shoppingCartItem; }
            set { _shoppingCartItem = value; }
        }

        // For One-to-One Relationship
        [Required]
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        [ForeignKey("CustomerId")]
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        // Methods
        public bool AddItem(Food food, int quantity)
        {
            return true;
        }

        public bool RemoveItem(Food food)
        {
            return true;
        }

        public decimal CalculateTotal()
        {
            return 0;
        }

        public void Clear() { }

        // Will be implemented in Phase 3
        // public Order ConvertToOrder()
        // {
        //     return new Order();
        // }
    }
}
