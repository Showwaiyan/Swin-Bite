using SwinBite.Interface;
using SwinBite.Models;
using SwinBite.Reposiroties;

namespace SwinBite.Services
{
    public class NotificationServices
    {
        private readonly NotificationRepository _repo;

        public NotificationServices(NotificationRepository repo)
        {
            _repo = repo;
        }

        public async Task NotifyRestaruantForNewOrder(Order order)
        {
            AddObserverForOrder(order, order.Restaurant);
            AddObserverForOrder(order, order.Customer);
            Notification notification = order.PlaceOrderNotification();
            order.NotifyObservers(notification);
            await _repo.SaveNotificationAsync(notification);
        }

        public void AddObserverForOrder(Order order, User user)
        {
            order.AddObserver(user as IObserver);
        }

        public void NotifyDeliveryDriversForNewOrder(
            Order order,
            List<DeliveryDriver> deliveryDrivers
        )
        {
            foreach (DeliveryDriver driver in deliveryDrivers)
            {
                AddObserverForOrder(order, driver);
            }
            Notification notification = order.NewOrderNotification();
            order.NotifyObservers(notification);
        }

        public void NotifyDeliverDriverAcceptOrder(Order order)
        {
          AddObserverForOrder(order,order.Customer);
          AddObserverForOrder(order,order.Restaurant);
          AddObserverForOrder(order,order.DeliveryDriver);
          Notification deliveryAcceptNotification = order.AcceptOrderNotification();
        }

        public void NotifyOrderStatus(Order order)
        {
            AddObserverForOrder(order,order.Customer);
            AddObserverForOrder(order,order.Restaurant);
            Notification notification = order.UpdateStatusNotification();
            order.NotifyObservers(notification);
        }
    }
}
