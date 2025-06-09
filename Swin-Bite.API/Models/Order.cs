using System.ComponentModel.DataAnnotations;

namespace SwinBite.Models
{
    public class Order
    {
        // Fields
        private int _orderId;
        private Customer _customer;
        private Restaurant _restaurant;
        private List<OrderItem> _orderItems;
        private decimal _totalPrice;
        private OrderStatus _status;
        private DateTime _orderDate;
        private DateTime _pickUpTime;

        // Properties
        [Key]
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        // Many-To-One Realtionship
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        // Many-To-One Relationship
        public Restaurant Restaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; }
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
        public bool UpdateStatus(OrderStatus status)
        {
            return true;
        }

        public decimal CalculateTotal()
        {
            return 0;
        }

        public bool CancelOrder()
        {
            return true;
        }
    }
}
