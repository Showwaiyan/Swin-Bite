using SwinBite.DTO;
using SwinBite.Models;

namespace SwinBite.Interface
{
    public interface ICustomerServices
    {
        public Task<Customer> Register(CreateCustomerDto registerCustomer);
        public Task<ShoppingCartItem> AddToCart(int customer, Food food, int quantity);
        public Task<ShoppingCartItem> RemoveFromCart(int customerId, Food food);
        public Task<Order> ConvertToOrder(int custoemrId, OrderType type);
        public Task<ShoppingCart> CheckOutCart(int customerID);
        public Task<Customer> GetCustomer(int id);
        public Task ClearCart(Customer customer);
        public Task<IEnumerable<Order>> GetOrders(int customerId);
        public Task<Order> GetOrder(int orderId, int customerId);
        public Task<Order> PickUpOrder(int orderId, int customerId);
        public Task<Order> CancellOrder(int orderId, int customerId)
    }
}
