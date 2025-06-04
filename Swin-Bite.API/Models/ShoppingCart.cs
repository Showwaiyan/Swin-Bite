using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class ShoppingCart
    {
        // Fields
        private List<Food> _items;
        private Dictionary<Food, int> _quantities;
        private int _customerId;

        private Customer _customer;

        // Properties
        public List<Food> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public Dictionary<Food, int> Quantities
        {
            get { return _quantities; }
            set { _quantities = value; }
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

        public Order ConvertToOrder()
        {
            return new Order();
        }
    }
}
