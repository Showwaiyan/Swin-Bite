namespace SwinBite.Models
{
    public class Restaurant : User
    {
        // Fields
        private string _name;
        private string _address;
        private float _rating;
        private List<Food> _menu; // Need to implement 1:many relationship
        private List<Order> _orders;
        private string _operatingHours;

        // Constructor
        public Restaurant()
        {
            _menu = new List<Food>();
            _orders = new List<Order>();
        }

        // Properties
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

        public List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public string OperatingHours
        {
            get { return _operatingHours; }
            set { _operatingHours = value; }
        }

        // Methods
        public Order ProcessOrder(Order order)
        {
            if (order.RestaurantId != UserId)
                throw new InvalidOperationException(
                    "This order does not belong to this restaurant."
                );
            order.Status = OrderStatus.Confirmed;
            return order;
        }

        public List<Food> GetMenu()
        {
            return new List<Food>() { };
        }

        public bool AddMenuItem(Food food)
        {
            return true;
        }

        public List<Order> ViewOrder()
        {
            return Orders;
        }

        public List<Food> ViewMenu()
        {
            return Menu;
        }

        public Order UpdateOrderStatus(int id, OrderStatus status)
        {
            Order order = GetOrder(id);
            if (order == null)
                throw new ArgumentException("We can't find order with this id!");
            order.UpdateStatus(status);
            if (status == OrderStatus.Cancelled || status == OrderStatus.Completed)
                if (!Orders.Remove(order))
                    throw new InvalidOperationException("Can't cancell the order!");
            return order;
        }

        public bool UpdateMenu()
        {
            return true;
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
