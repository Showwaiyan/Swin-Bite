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
            Notification notification = order.PlaceOrderNotification();
            await _repo.SaveNotificationAsync(notification);
        }

        public void AddObserverForOrder(Order order, User user)
        {
            order.AddObserver(user as IObserver);
        }

        public async Task NotifyDeliveryDriversForNewOrder(
            Order order,
            List<DeliveryDriver> deliveryDrivers
        )
        {
            foreach (DeliveryDriver driver in deliveryDrivers)
            {
                Notification newOrderNotifcation = new Notification()
                {
                    Message =
                        $"Order from {order.Restaurant.Name} is placed for delivery, from {order.Restaurant.Address} to {order.Customer.Address}",
                    UserId = driver.UserId,
                    TimeStamp = DateTime.UtcNow,
                    Type = NotificationType.OrderUpdate,
                    IsRead = false,
                };
                driver.Update(newOrderNotifcation);
                await _repo.SaveNotificationAsync(newOrderNotifcation);
            }
        }

        public void NotifyOrderStatus(Order order)
        {
            order.UpdateStatusNotification();
        }
    }
}
