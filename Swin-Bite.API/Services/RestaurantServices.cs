using SwinBite.Models;
using SwinBite.Reposiroties;

namespace SwinBite.Services
{
    public class RestaurantServices
    {
        private readonly RestaurantRepository _repo;

        public RestaurantServices(RestaurantRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            return await _repo.GetAllRestaurantAsync();
        }

        public async Task<IEnumerable<Food>> GetMenu(int restaurantId)
        {
            Restaurant restaurant = await _repo.GetRestaruantByIdAsync(restaurantId);
            if (restaurant == null)
                throw new ArgumentException("There is no such restaurant");
            return restaurant.ViewMenu();
        }

        public async Task<IEnumerable<Restaurant>> FindRestaruantsByName(string name)
        {
            IEnumerable<Restaurant> restaurants = await _repo.GetRestaruantByNameAsync(name);
            if (restaurants == null)
                return null;

            return restaurants;
        }

        public async Task<Restaurant> GetRestaurant(int id)
        {
            return await _repo.GetRestaruantByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrders(int restaurantId)
        {
            Restaurant restaurant = await GetRestaurant(restaurantId);
            if (restaurant == null)
                throw new ArgumentException("We can't find restaurant with this id.");
            List<Order> orders = restaurant.GetOrders();
            return orders;
        }

        public async Task<Order> GetOrder(int orderId, int restaurantId)
        {
            Restaurant restaurant = await GetRestaurant(restaurantId);

            Order order = restaurant.GetOrder(orderId);
            if (order == null)
                throw new ArgumentException("We can't find order with this id.");
            return order;
        }

        public async Task<Order> UpdateOrderStatus(int orderId, OrderStatus status, int restaurantId)
        {
          Order order = await GetOrder(orderId, restaurantId);
          order.UpdateStatus(status); 
          return order;
        }
    }
}
