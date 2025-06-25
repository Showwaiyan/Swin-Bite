using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class ShoppingCart
    {
        // Fields
        private int _shoppingCartId;
        private int _customerId;
        private Customer _customer;
        private List<ShoppingCartItem> _shoppingCartItems;
        private decimal _totalPrice;

        // constructor
        public ShoppingCart()
        {
            _shoppingCartItems = new List<ShoppingCartItem>();
        }

        // Properties
        [Key]
        public int ShoppingCartId
        {
            get { return _shoppingCartId; }
            set { _shoppingCartId = value; }
        }

        public List<ShoppingCartItem> ShoppingCartItems
        {
            get { return _shoppingCartItems; }
            set { _shoppingCartItems = value; }
        }

        // For One-to-One Relationship
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

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        // Methods
        public ShoppingCartItem AddItem(Food food, int quantity)
        {
            ShoppingCartItem item = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId,
                Quantity = quantity,
                FoodId = food.FoodId,
            };
            ShoppingCartItems.Add(item);
            return item;
        }

        public bool RemoveItem(Food food)
        {
            return true;
        }

        public decimal CalculateTotal()
        {
            return ShoppingCartItems.Sum(i => i.Quantity * i.Food.Price);
        }

        public void Clear() { }

        public Order ConvertToOrder()
        {
            if (ShoppingCartItems == null || !ShoppingCartItems.Any())
                throw new InvalidOperationException("Cannot create order from empty shopping ");

            // Creating Order
            Order order = new Order()
            {
                CustomerId = CustomerId,
                RestaurantId = ShoppingCartItems.First().Food.RestaurantId,
                OrderItems = new List<OrderItem>(),
                Status = OrderStatus.Pending,
                OrderDate = DateTime.UtcNow,
                PickUpTime = DateTime.UtcNow.AddMinutes(30), // HardCoded value now
            };

            // Create orderItems and assigned each shoppingCartItem to it
            foreach (ShoppingCartItem item in ShoppingCartItems)
            {
                OrderItem orderItem = new OrderItem()
                {
                    Order = order,
                    FoodId = item.FoodId,
                    Quantity = item.Quantity,
                    PriceAtTime = item.Food.Price,
                };
                // and these orderItem is assigned to order
                order.OrderItems.Add(orderItem);
            }

            // Computing Total Price
            order.TotalPrice = order.CalculateTotal();

            return order;
        }
    }
}
