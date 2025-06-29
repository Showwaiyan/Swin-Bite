using SwinBite.Interface;

namespace SwinBite.Models
{
    public class DeliveryDriver : User, IObserver
    {
        // Fields
        private VehicleType _vehicle;
        private string _licenseNumber;
        private bool _isAvailable;
        private List<Order> _orders;

        // Constructor
        public DeliveryDriver()
        {
            _orders = new List<Order>();
        }

        // Properties
        public VehicleType Vehivle
        {
            get { return _vehicle; }
            set { _vehicle = value; }
        }

        public string LicenseNumber
        {
            get { return _licenseNumber; }
            set { _licenseNumber = value; }
        }

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }

        public List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        // Methods
        public void Update(Notification notification)
        {
            AddNotification(notification);

            if (notification.Type == NotificationType.OrderUpdate && IsAvailable)
            {
                CheckForDeliveryOpportunity(notification);
            }
        }

        private void CheckForDeliveryOpportunity(Notification notification)
        {
            Console.WriteLine(
                $"Driver {Username} received notification: {notification.GetContent()}\n"
            );
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
            if (status == OrderStatus.Cancelled)
                if (!Orders.Remove(order))
                    throw new InvalidOperationException("Can't cancell the order!");
            order.UpdateStatus(status);
            return order;
        }
    }
}
