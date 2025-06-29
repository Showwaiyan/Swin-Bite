using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.Models;

namespace SwinBite.Reposiroties
{
    public class DeliveryDriverRepository
    {
        private readonly AppDbContext _context;

        public DeliveryDriverRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DeliveryDriver>> GetAllDeliveryAsync()
        {
            return await _context
                .DeliveryDrivers.Where(d => d.IsAvailable == true)
                .Include(d => d.Notifications)
                .ToListAsync();
        }

        public async Task<DeliveryDriver> GetDeliveryDriverByIdAsync(int id)
        {
          return await _context.DeliveryDrivers.Include(d=>d.Deliveries).FirstOrDefaultAsync(d=>d.UserId == id);
        }
    }
}
