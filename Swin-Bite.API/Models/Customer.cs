using System.ComponentModel.DataAnnotations;

namespace SwinBite.Models
{
    public class Customer : User
    {
        // Fields
        private ShoppingCart _shoppingCart;
        private List<Order> _orders;

        // Properties
        [Required]
        public ShoppingCart ShoppingCart // One-to-One relationship
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        public List<Order> Orders // One-to-Many relationship (! Need to implement later)
        {
            get { return _orders; }
            set { _orders = value; }
        }

        // Methods
        public ShoppingCartItem AddToCart(Food food, int quantity)
        {
            return ShoppingCart.AddItem(food, quantity);
        }

        public Order PlaceOrder()
        {
            return ShoppingCart.ConvertToOrder();
        }

        public List<Order> GetOrders()
        {
          return Orders;
        }

        public void ClearCart()
        {
            ShoppingCart.ShoppingCartItems.Clear();
        }
    }
}
