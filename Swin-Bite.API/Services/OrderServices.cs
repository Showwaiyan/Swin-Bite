using SwinBite.Models;
using SwinBite.Reposiroties;

namespace SwinBite.Services
{
    public class OrderServices
    {
        private readonly OrderRepository _repo;

        public OrderServices(OrderRepository repo)
        {
            _repo = repo;
        }

        public async Task<Order> GetOrder(int orderId)
        {
            Order order = await _repo.GetOrderByAsync(orderId);
            if (order == null)
                throw new ArgumentException("We can't find order with this id!");
            return order;
        }

        public async Task SaveOrder(Order order)
        {
            await _repo.SaveOrder(order);
        }

        public async Task UpdateOrder(Order order)
        {
          await _repo.UpdateOrder(order);
        }
    }
}
