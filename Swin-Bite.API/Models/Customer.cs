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

        public List<Order> Orders
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

        public void ClearCart()
        {
            ShoppingCart.ShoppingCartItems.Clear();
        }

        public List<Order> GetOrders()
        {
            return Orders;
        }

        public Order GetOrder(int id)
        {
            Order order = Orders.Find(o => o.OrderId == id);
            return order;
        }
    }
}
