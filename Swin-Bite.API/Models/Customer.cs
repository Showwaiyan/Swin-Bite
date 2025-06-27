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

        public Order PickUpOrder(int orderId)
        {
            Order order = GetOrder(orderId);
            if (order == null)
                throw new ArgumentException("We can't find order with this id!");
            order.UpdateStatus(OrderStatus.Completed);
            if (!Orders.Remove(order))
                throw new InvalidOperationException("Can't confirm the order!");

            return order;
        }

        public Order CancellOrder(int orderId)
        {
            Order order = GetOrder(orderId);
            if (order.Status != OrderStatus.Pending)
                throw new InvalidOperationException("You can't cancell confirmed Order!");

            order.UpdateStatus(OrderStatus.Cancelled);
            if (!Orders.Remove(order))
                throw new InvalidOperationException("Can't cancell the order!");

            return order;
        }
    }
}
