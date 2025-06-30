using System.ComponentModel.DataAnnotations;
using SwinBite.Interface;

namespace SwinBite.Models
{
    public class Customer : User, IObserver
    {
        // Fields
        private ShoppingCart _shoppingCart;
        private List<Order> _orders;

        // Constructor
        public Customer()
            : base()
        {
            _orders = new List<Order>();
        }

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

        public Order PlaceOrder(OrderType type)
        {
            return ShoppingCart.ConvertToOrder(type);
        }

        public void ClearCart()
        {
            ShoppingCart.Clear();
        }

        public List<Order> GetOrders()
        {
            return Orders;
        }

        public Order GetOrder(int id)
        {
            Order order = Orders.Find(o => o.OrderId == id);
            if (order == null)
                throw new ArgumentException("We can't find order with this id!");
            return order;
        }

        public Order PickUpOrder(int orderId)
        {
            Order order = GetOrder(orderId);
            order.UpdateStatus(OrderStatus.Completed);
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

        // Every Notifcation using Observer pattern will be shown by Console WriteLine
        // Using Console WriteLine in each class is not good pratice, however
        // Showing actual push notification is limited due to web api project
        public void Update(Notification notification)
        {
            AddNotification(notification);
            Console.WriteLine(
                $"Customer {Username} received notification: {notification.GetContent()}"
            );

            // Customer-specific behavior based on notification type
            switch (notification.Type)
            {
                case NotificationType.OrderUpdate:
                    HandleOrderUpdate(notification);
                    break;
                case NotificationType.DeliveryUpdate:
                    HandleDeliveryUpdate(notification);
                    break;
                case NotificationType.Promotion:
                    HandlePromotion(notification);
                    break;
            }
        }

        private void HandleOrderUpdate(Notification notification)
        {
            Console.WriteLine($"Customer {Username}: Checking order status...\n");
        }

        private void HandleDeliveryUpdate(Notification notification)
        {
            Console.WriteLine($"Customer {Username}: Preparing for delivery arrival...\n");
        }

        private void HandlePromotion(Notification notification)
        {
            Console.WriteLine($"Customer {Username}: New promotion available!\n");
        }
    }
}
