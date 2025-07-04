using SwinBite.Models;
using SwinBite.Reposiroties;

namespace SwinBite.Services
{
    public class CustomerServices
    {
        private readonly CustomerRepository _repo;

        public CustomerServices(CustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<ShoppingCartItem> AddToCart(int customerId, Food food, int quantity)
        {
            if (quantity <= 0)
                throw new InvalidDataException("Quantity can't be zero or negative!");

            Customer customer = await _repo.GetByIdAsync(customerId);
            if (customer == null)
                throw new ArgumentException("We can't find customer with this id!");

            ShoppingCartItem item = customer.ShoppingCart.AddItem(food, quantity);
            await _repo.AddToCart(item);

            return item;
        }

        public async Task<ShoppingCartItem> RemoveFromCart(int customerId, Food food)
        {
            Customer customer = await _repo.GetByIdAsync(customerId);
            if (customer == null)
                throw new ArgumentException("We can't find customer with this id!");

            ShoppingCartItem item = customer.ShoppingCart.RemoveItem(food);
            await _repo.RemoveFromCart(item);
            return item;
        }

        public async Task<Order> ConvertToOrder(int customerId, OrderType type)
        {
            Customer customer = await _repo.GetByIdAsync(customerId);

            if (customer == null)
                throw new ArgumentException("We can't find customer with this id!");

            Order order = customer.PlaceOrder(type);

            return order;
        }

        public async Task<ShoppingCart> CheckOutCart(int customerId)
        {
            Customer customer = await _repo.GetByIdAsync(customerId);

            if (customer == null)
                throw new ArgumentException("We can't find customer with this id!");

            ShoppingCart cart = customer.ShoppingCart;
            cart.TotalPrice = cart.CalculateTotal();

            return cart;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer = await _repo.GetByIdAsync(id);
            if (customer == null)
                throw new ArgumentException("We can't find customer with this id!");
            return customer;
        }

        public async Task ClearCart(Customer customer)
        {
            customer.ClearCart();
            await _repo.ClearCart(customer);
        }

        public async Task<IEnumerable<Order>> GetOrders(int customerId)
        {
            Customer customer = await GetCustomer(customerId);
            if (customer == null)
                throw new ArgumentException("We can't find customer with this id.");
            List<Order> orders = customer.GetOrders();
            return orders;
        }

        public async Task<Order> GetOrder(int orderId, int customerId)
        {
            Customer customer = await GetCustomer(customerId);

            Order order = customer.GetOrder(orderId);
            if (order == null)
                throw new ArgumentException("We can't find order with this id.");
            return order;
        }

        public async Task<Order> PickUpOrder(int orderId, int customerId)
        {
            Customer customer = await GetCustomer(customerId);
            Order order = customer.PickUpOrder(orderId);
            return order;
        }

        public async Task<Order> CancellOrder(int orderId, int customerId)
        {
            Customer customer = await GetCustomer(customerId);
            Order order = customer.CancellOrder(orderId);
            return order;
        }
    }
}
