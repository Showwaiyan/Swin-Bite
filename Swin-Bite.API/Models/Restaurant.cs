namespace SwinBite.Models
{
    public class Restaurant
    {
        // Fields
        private int _restaurantId;
        private string _name;
        private string _address;
        private float _rating;
        private List<Food> _menu; // Need to implement 1:many relationship
        private string _operatingHours;

        // Properties
        public int RestaurantId
        {
            get { return _restaurantId; }
            set { _restaurantId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public float Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        public List<Food> Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        public string OperatingHours
        {
            get { return _operatingHours; }
            set { _operatingHours = value; }
        }

        // Methods
        public bool ProcessOrder(int orderId)
        {
            return true;
        }

        public List<Food> GetMenu()
        {
            return new List<Food>() { };
        }

        public bool AddMenu(Food food)
        {
            return true;
        }

        public List<Order> ViewOrder()
        {
            return new List<Order>() { };
        }

        public bool UpdateOrderStatus(int orderId, OrderStatus status)
        {
            return true;
        }

        public bool UpdateMenu()
        {
            return true;
        }
    }
}
