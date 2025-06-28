namespace SwinBite.Models
{
    public class DeliveryDriver : User
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
    }
}
