using SwinBite.Interface;

namespace SwinBite.Models
{
    public class Restaurant : User, IObserver
    {
        public string Name { get; set; }
        public float Rating { get; set; }

        // One-to-Many: One Restaurant has many Foods
        public List<Food> Menu { get; set; } = new List<Food>();

        // One-to-Many: One Restaurant has many Orders
        public List<Order> Orders { get; set; } = new List<Order>();

        public string OperatingHours { get; set; }

        // Process an order and mark as confirmed
        public Order ProcessOrder(Order order)
        {
            if (order.RestaurantId != UserId)
                throw new InvalidOperationException(
                    "This order does not belong to this restaurant."
                );

            order.Status = OrderStatus.Confirmed;
            return order;
        }

        public void AddMenuItem(Food food)
        {
            Menu.Add(food);
        }

        public void UpdateMenu(Food food)
        {
            int index = Menu.FindIndex(f => f.FoodId == food.FoodId);
            if (index == -1)
                throw new InvalidOperationException("Can't update non-existing item!");
            Menu[index] = food;
        }

        public Order UpdateOrderStatus(int id, OrderStatus status)
        {
            var order = GetOrder(id);
            if (status == OrderStatus.Cancelled)
            {
                if (!Orders.Remove(order))
                    throw new InvalidOperationException("Can't cancel the order!");
            }
            order.UpdateStatus(status);
            return order;
        }

        public Order GetOrder(int id)
        {
            var order = Orders.Find(o => o.OrderId == id);
            if (order == null)
                throw new ArgumentException("We can't find an order with this ID!");
            return order;
        }

        // Observer Pattern: Receive and react to notifications
        public void Update(Notification notification)
        {
            AddNotification(notification);
            Console.WriteLine(
                $"Restaurant {Name} received notification: {notification.GetContent()}"
            );

            if (notification.Type == NotificationType.OrderUpdate)
                HandleNewOrder(notification);
            else if (notification.Type == NotificationType.DeliveryUpdate)
                HandleDeliveryPickUp(notification);
        }

        private void HandleNewOrder(Notification notification)
        {
            Console.WriteLine($"Restaurant {Name}: Processing new order notification...\n");
        }

        private void HandleDeliveryPickUp(Notification notification)
        {
            Console.WriteLine($"Restaurant {Name}: Delegating order for delivery...\n");
        }
    }
}
