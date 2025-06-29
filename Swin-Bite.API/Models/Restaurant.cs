using SwinBite.Interface;

namespace SwinBite.Models
{
    public class Restaurant : User, IObserver
    {
        // Fields
        private string _name;
        private float _rating;
        private List<Food> _menu; // Need to implement 1:many relationship
        private List<Order> _orders;
        private string _operatingHours;

        // Constructor
        public Restaurant()
            : base()
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

        public void AddMenuItem(Food food)
        {
            Menu.Add(food);
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

        public void UpdateMenu(Food food)
        {
            int index = Menu.FindIndex(f => f.FoodId == food.FoodId);
            if (index == -1)
                throw new InvalidOperationException("Can't update non-existing item!");
            Menu[index] = food;
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

        // Every Notifcation using Observer pattern will be shown by Console WriteLine
        // Using Console WriteLine in each class is not good pratice, however
        // Showing actual push notification is limited due to web api project
        public void Update(Notification notification)
        {
            AddNotification(notification);
            Console.WriteLine(
                $"Restaurant {Name} received notification: {notification.GetContent()}"
            );

            if (notification.Type == NotificationType.OrderUpdate)
            {
                HandleNewOrder(notification);
            }
        }

        private void HandleNewOrder(Notification notification)
        {
            Console.WriteLine($"Restaurant {Name}: Processing new order notification...");
        }
    }
}
