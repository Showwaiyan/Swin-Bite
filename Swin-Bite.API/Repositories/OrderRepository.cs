using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.Models;

namespace SwinBite.Reposiroties
{
  public class OrderRepository
  {
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task SaveOrder(Order order)
    {
      await _context.Orders.AddAsync(order);
      await _context.SaveChangesAsync();
    }
  }
}
