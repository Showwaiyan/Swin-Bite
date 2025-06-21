using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.Models;

namespace SwinBite.Reposiroties
{
    public class RestaurantRepository
    {
        private readonly AppDbContext _context;

        public RestaurantRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all
        public async Task<IEnumerable<Restaurant>> GetAllRestaurantAsync()
        {
            return await _context
                .Restaurants.Include(r => r.Menu)
                .Include(r => r.Orders)
                .ToListAsync();
        }

        // Get by id
        public async Task<Restaurant> GetRestaruantByIdAsync(int id)
        {
            return await _context
                .Restaurants.Include(r => r.Menu)
                .Include(r => r.Orders)
                .FirstOrDefaultAsync(r => r.UserId == id);
        }

        // Get by Name
        public async Task<IEnumerable<Restaurant>> GetRestaruantByNameAsync(string name)
        {
            return await _context
                .Restaurants.Include(r => r.Menu)
                .Include(r => r.Orders)
                .Where(r => r.Name.Contains(name))
                .ToListAsync();
        }
    }
}
