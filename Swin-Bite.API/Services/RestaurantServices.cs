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

        public async Task<IEnumerable<Restaurant>> BrowseRestaurant()
        {
          return await _repo.GetAllRestaurant();
        }

        public async Task<IEnumerable<Food>> GetMenu(int restaurantId)
        {
          return await _repo.GetMenuByRestaurantId(restaurantId);
        }
    }
}
