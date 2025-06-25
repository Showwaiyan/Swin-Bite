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

        public async Task<Order> UpdateOrderStatus(Order order, OrderStatus status)
        {
            Restaurant restaurant = await _repo.GetRestaruantByIdAsync(order.RestaurantId);
            if (restaurant == null)
                throw new InvalidOperationException(
                    "This order does not belong to this restaurant"
                );
            return restaurant.UpdateOrderStatus(order, status);
        }
    }
}
