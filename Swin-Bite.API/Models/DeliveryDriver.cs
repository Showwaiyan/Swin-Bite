using SwinBite.Interface;

namespace SwinBite.Models
{
    public class DeliveryDriver : User, IObserver
    {
        // Constructor
        public DeliveryDriver()
        {
            Orders = new List<Order>();
        }

        // Properties
        public VehicleType Vehivle { get; set; }

        public string LicenseNumber { get; set; }

        public bool IsAvailable { get; set; }

        public List<Order> Orders { get; set; }

        // Methods
        public void Update(Notification notification)
        {
            AddNotification(notification);
            Console.WriteLine(
                $"Driver {Username} received notification: {notification.GetContent()}"
            );
            if (notification.Type == NotificationType.OrderUpdate && IsAvailable)
            {
                CheckForDeliveryOpportunity(notification);
            }
            else
                DeliveredOrder(notification);
        }

        private void CheckForDeliveryOpportunity(Notification notification)
        {
            Console.WriteLine($"Finding Order Opportunity.\n");
        }

        private void DeliveredOrder(Notification notification)
        {
            Console.WriteLine("Order has been delivered.\n");
        }

        public Order GetOrder(int id)
        {
            Order order = Orders.Find(o => o.OrderId == id);
            return order;
        }

        public Order UpdateOrderStatus(int id, OrderStatus status)
        {
            Order order = GetOrder(id);
            if (order == null)
                throw new ArgumentException("We can't find order with this id!");
            order.UpdateStatus(status);
            return order;
        }
    }
}
