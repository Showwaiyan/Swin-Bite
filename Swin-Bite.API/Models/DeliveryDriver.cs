using SwinBite.Interface;

namespace SwinBite.Models
{
    public class DeliveryDriver : User, IObserver
    {
        // Fields
        private VehicleType _vehicle;
        private string _licenseNumber;
        private bool _isAvailable;
        private List<Order> _deliveries;

        // Constructor
        public DeliveryDriver()
        {
            _deliveries = new List<Order>();
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

        public List<Order> Deliveries
        {
            get { return _deliveries; }
            set { _deliveries = value; }
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
    }
}
