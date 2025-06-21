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

        public async Task<IEnumerable<Restaurant>> FindRestaruants(string name)
        {
            IEnumerable<Restaurant> restaurants = await _repo.GetRestaruantByNameAsync(name);
            if (restaurants == null)
                return null;

            return restaurants;
        }
    }
}
