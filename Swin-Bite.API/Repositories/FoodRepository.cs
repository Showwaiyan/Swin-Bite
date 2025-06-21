using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.Models;

namespace SwinBite.Reposiroties
{
  public class FoodRepository
  {
    private readonly AppDbContext _context;

    public FoodRepository(AppDbContext context)
    {
      _context = context;
    }

    // Get by Id
    public async Task<Food> GetFoodByIdAsync(int id)
    {
      return await _context.Foods.Include(f=>f.Restaurant).FirstOrDefaultAsync(f=>f.FoodId == id);
    }
  }
}
