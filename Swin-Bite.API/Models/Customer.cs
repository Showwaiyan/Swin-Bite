using System.ComponentModel.DataAnnotations;
using SwinBite.Interfaces;

namespace SwinBite.Models
{
    public class Customer : User, IReport
    {
        // Fields
        private ShoppingCart _shoppingCart;
        private List<Order> _orders;

        // Properties
        [Required]
        public ShoppingCart ShoppingCart // One-to-One relationship
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        public List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        // Methods
        public ShoppingCartItem AddToCart(Food food, int quantity)
        {
            return ShoppingCart.AddItem(food, quantity);
        }

        public Order PlaceOrder()
        {
            return ShoppingCart.ConvertToOrder();
        }

        public void ClearCart()
        {
            ShoppingCart.Clear();
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

        public Order PickUpOrder(int orderId)
        {
            Order order = GetOrder(orderId);
            if (order == null)
                throw new ArgumentException("We can't find order with this id!");
            order.UpdateStatus(OrderStatus.Completed);
            if (!Orders.Remove(order))
                throw new InvalidOperationException("Can't confirm the order!");

            return order;
        }

        public Order CancellOrder(int orderId)
        {
            Order order = GetOrder(orderId);
            if (order.Status != OrderStatus.Pending)
                throw new InvalidOperationException("You can't cancell confirmed Order!");

            order.UpdateStatus(OrderStatus.Cancelled);
            if (!Orders.Remove(order))
                throw new InvalidOperationException("Can't cancell the order!");

            return order;
        }

        public string GenerateMonthlyReport()
        {
            // This resolves to your project root:
            string projectRoot = Directory.GetCurrentDirectory();

            // Combine it with your Reports/ folder:
            string reportsFolder = Path.Combine(projectRoot, "Reports");

            // Ensure the folder exists:
            if (!Directory.Exists(reportsFolder))
            {
                Directory.CreateDirectory(reportsFolder);
                Console.WriteLine($"Created folder: {reportsFolder}");
            }

            // Define file path
            string fileName = $"Report_C{UserId}{Username}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string filePath = Path.Combine(reportsFolder, fileName);
            // Calculate the date range for one month back
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);

            // Filter this customer's orders from last month
            List<Order> monthlyOrders = Orders
                .Where(o => o.OrderDate >= oneMonthAgo)
                .OrderBy(o => o.OrderDate)
                .ToList();

            decimal totalCost = 0;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Monthly Order Report for Customer: {Username} (ID {UserId})");
                writer.WriteLine($"Period: {oneMonthAgo:yyyy-MM-dd} to {DateTime.Now:yyyy-MM-dd}");
                writer.WriteLine();

                if (monthlyOrders.Any())
                {
                    writer.WriteLine("Orders:");
                    foreach (var order in monthlyOrders)
                    {
                        writer.WriteLine(
                            $"OrderId: {order.OrderId}, Date: {order.OrderDate:yyyy-MM-dd}, Total: ${order.TotalPrice:F2}"
                        );
                        totalCost += order.TotalPrice;
                    }

                    writer.WriteLine();
                    writer.WriteLine($"TOTAL COST: ${totalCost:F2}");
                }
                else
                {
                    writer.WriteLine("No orders found for this period.");
                }
            }

            Console.WriteLine($"Report generated at: {filePath}");
            return filePath;
        }
    }
}
