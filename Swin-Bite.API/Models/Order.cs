using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SwinBite.Interface;

namespace SwinBite.Models
{
    public class Order : ISubject
    {
        // Constructor
        public Order()
        {
            OrderItems = new List<OrderItem>();
            Observers = new List<IObserver>();
        }

        // Properties
        [Key]
        public int OrderId { get; set; }

        // Many-To-One Relationship
        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        // Many-To-One Relationship
        [Required]
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }

        // Optional Delivery Driver
        public int? DeliveryDriverId { get; set; }

        [ForeignKey("DeliveryDriverId")]
        public DeliveryDriver DeliveryDriver { get; set; }

        // One-To-Many Relationship
        public List<OrderItem> OrderItems { get; set; }

        public decimal TotalPrice { get; set; }

        public OrderStatus Status { get; set; }

        public OrderType Type { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime PickUpTime { get; set; }

        public List<IObserver> Observers { get; } // read-only, initialized in constructor

        // Methods
        public Notification PlaceOrderNotification()
        {
            return new Notification
            {
                Message =
                    $"Customer {Customer.Username}(ID-{CustomerId}) place order with Order(ID-{OrderId}) at {OrderDate:yyyy-MM-dd HH:mm}",
                UserId = RestaurantId,
                TimeStamp = DateTime.UtcNow,
                Type = NotificationType.OrderUpdate,
                IsRead = false,
            };
        }

        public Notification NewOrderNotification()
        {
            return new Notification
            {
                Message =
                    $"Order(Id={OrderId}) from {Restaurant.Name} is placed for delivery, from {Restaurant.Address} to {Customer.Address}",
                TimeStamp = DateTime.UtcNow,
                Type = NotificationType.OrderUpdate,
                IsRead = false,
            };
        }

        public Notification AcceptOrderNotification()
        {
            return new Notification
            {
                Message =
                    $"Driver {DeliveryDriver.Username} accept Order(Id-{OrderId}) and currently on the way.",
                UserId = RestaurantId,
                TimeStamp = DateTime.UtcNow,
                Type = NotificationType.DeliveryUpdate,
                IsRead = false,
            };
        }

        public Notification DeliveredOrderNotification()
        {
            return new Notification
            {
                Message =
                    $"Delivery {DeliveryDriver.Username} has delivered Order (Id-{OrderId}) at {Customer.Address}",
                UserId = CustomerId,
                TimeStamp = DateTime.UtcNow,
                Type = NotificationType.DeliveryUpdate,
                IsRead = false,
            };
        }

        public Notification CompleteOrderNotification()
        {
            return new Notification
            {
                Message = $"Customer {Customer.Username} picked up order.",
                UserId = RestaurantId,
                TimeStamp = DateTime.UtcNow,
                Type = NotificationType.DeliveryUpdate,
                IsRead = false,
            };
        }

        public Notification UpdateStatusNotification()
        {
            return new Notification
            {
                Message = $"Order #{OrderId} status updated to {Status}",
                UserId = CustomerId,
                TimeStamp = DateTime.UtcNow,
                Type = NotificationType.OrderUpdate,
                IsRead = false,
            };
        }

        public void UpdateStatus(OrderStatus status)
        {
            Status = status;
        }

        public decimal CalculateTotal()
        {
            return OrderItems.Sum(i => i.Quantity * i.PriceAtTime);
        }

        public void AddObserver(IObserver observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if (Observers.Contains(observer))
            {
                Observers.Remove(observer);
            }
        }

        public void NotifyObservers(Notification notification)
        {
            foreach (IObserver observer in Observers)
            {
                observer.Update(notification);
            }
        }
    }
}

