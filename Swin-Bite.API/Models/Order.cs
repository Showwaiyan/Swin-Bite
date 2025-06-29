using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SwinBite.Interface;

namespace SwinBite.Models
{
    public class Order : ISubject
    {
        // Fields
        private int _orderId;
        private int _customerId;
        private Customer _customer;
        private int _restaurantId;
        private Restaurant _restaurant;
        private int? _deliveryDriverId;
        private DeliveryDriver _deliveryDriver;
        private List<OrderItem> _orderItems;
        private decimal _totalPrice;
        private OrderStatus _status;
        private OrderType _type;
        private DateTime _orderDate;
        private DateTime _pickUpTime;

        private List<IObserver> _observers;

        // Constructor
        public Order()
        {
            _orderItems = new List<OrderItem>();
            _observers = new List<IObserver>();
        }

        // Properties
        [Key]
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        // Many-To-One Realtionship
        [Required]
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        [ForeignKey("CustomerId")]
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        // Many-To-One Relationship
        [Required]
        public int RestaurantId
        {
            get { return _restaurantId; }
            set { _restaurantId = value; }
        }

        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; }
        }

        // Many-To-Zero Relationship
        public int? DeliveryDriverId
        {
            get { return _deliveryDriverId; }
            set { _deliveryDriverId = value; }
        }

        [ForeignKey("DeliveryDriverId")]
        public DeliveryDriver DeliveryDriver
        {
            get { return _deliveryDriver; }
            set { _deliveryDriver = value; }
        }

        // One-To-Many Relationship
        public List<OrderItem> OrderItems
        {
            get { return _orderItems; }
            set { _orderItems = value; }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        public OrderStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public OrderType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        public DateTime PickUpTime
        {
            get { return _pickUpTime; }
            set { _pickUpTime = value; }
        }

        // Methods
        public void UpdateStatus(OrderStatus status)
        {
            Status = status;
            Notification notification = new Notification
            {
                Message = $"Order #{OrderId} status updated to {status}",
                TimeStamp = DateTime.Now,
                Type = NotificationType.OrderUpdate,
                IsRead = false,
            };
            NotifyObservers(notification);
        }

        public decimal CalculateTotal()
        {
            return OrderItems.Sum(i => i.Quantity * i.PriceAtTime);
        }

        public void AddObserver(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void NotifyObservers(Notification notification)
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(notification);
            }
        }
    }
}
