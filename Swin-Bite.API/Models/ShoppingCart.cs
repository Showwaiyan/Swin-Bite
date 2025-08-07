using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

        public decimal TotalPrice { get; set; }

        // Add item to cart
        public ShoppingCartItem AddItem(Food food, int quantity)
        {
            var item = ShoppingCartItems.FirstOrDefault(i => i.FoodId == food.FoodId);
            if (item == null)
            {
                item = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    FoodId = food.FoodId,
                    Quantity = quantity
                };
                ShoppingCartItems.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }

            return item;
        }

        // Remove item from cart
        public ShoppingCartItem RemoveItem(Food food)
        {
            var itemToRemove = ShoppingCartItems.FirstOrDefault(i => i.FoodId == food.FoodId);
            if (itemToRemove == null)
                throw new InvalidOperationException("You can't remove a non-existing item!");

            ShoppingCartItems.Remove(itemToRemove);
            return itemToRemove;
        }

        // Total price calculator
        public decimal CalculateTotal()
        {
            return ShoppingCartItems.Sum(i => i.Quantity * i.Food.Price);
        }

        // Clear the cart
        public void Clear()
        {
            ShoppingCartItems.Clear();
        }

        // Convert cart to order
        public Order ConvertToOrder(OrderType type)
        {
            if (!ShoppingCartItems.Any())
                throw new InvalidOperationException("Cannot create an order from an empty cart.");

            var order = new Order
            {
                CustomerId = CustomerId,
                RestaurantId = ShoppingCartItems.First().Food.RestaurantId,
                OrderItems = new List<OrderItem>(),
                Status = OrderStatus.Pending,
                OrderDate = DateTime.UtcNow,
                PickUpTime = DateTime.UtcNow.AddMinutes(30),
                Type = type
            };

            foreach (var item in ShoppingCartItems)
            {
                var orderItem = new OrderItem
                {
                    FoodId = item.FoodId,
                    Quantity = item.Quantity,
                    PriceAtTime = item.Food.Price,
                    Order = order // Keeping the reference — correct if not saving yet
                };

                order.OrderItems.Add(orderItem);
            }

            order.TotalPrice = order.CalculateTotal();
            return order;
        }
    }
}

