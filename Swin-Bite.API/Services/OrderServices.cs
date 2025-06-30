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

        public async Task<Order> FetchCustomerRestaurantAndDelivery(Order order)
        {
            order = await _repo.GetOrderByIdAsync(order.OrderId);
            return order;
        }

        public async Task<List<Order>> GetAllDeliverableOrder()
        {
            return await _repo.GetAllOrderWithNoDeliveryDriver();
        }

        public async Task<Order> GetOrderById(int id)
        {
            Order order = await _repo.GetOrderByIdAsync(id);
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
