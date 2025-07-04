using SwinBite.Models;
using SwinBite.Reposiroties;

namespace SwinBite.Services
{
    public class FoodServices
    {
        private readonly FoodRepository _repo;

        public FoodServices(FoodRepository repo)
        {
            _repo = repo;
        }

        public async Task<Food> GetFood(int id)
        {
            Food food = await _repo.GetFoodByIdAsync(id);
            if (food == null)
                throw new ArgumentException("We can't find food with this id!");
            return food;
        }

        public async Task<bool> AddMenu(Food food)
        {
            await _repo.AddFoodAsync(food);
            return true;
        }

        public async Task<bool> UpdateMenu(Food food)
        {
          await _repo.UpdateFoodAsync(food);
          return true;
        }
    }
}
