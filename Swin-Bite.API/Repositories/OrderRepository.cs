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

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context
                .Orders.Include(o => o.Customer)
                .Include(o => o.Restaurant)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task SaveOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
          _context.Orders.Update(order);
          await _context.SaveChangesAsync();
        }
        
        public async Task DeleteOrder(Order order)
        {
          _context.Orders.Remove(order);
          await _context.SaveChangesAsync();
        }
    }
}
