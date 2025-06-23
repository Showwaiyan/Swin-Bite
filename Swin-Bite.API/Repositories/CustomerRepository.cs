using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.Models;

namespace SwinBite.Reposiroties
{
    public class CustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get by id
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context
                .Customers.Include(c => c.BankAccount)
                .Include(c => c.ShoppingCart)
                .ThenInclude(s => s.ShoppingCartItems)
                .ThenInclude(si => si.Food)
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderItems)
                .FirstOrDefaultAsync(c => c.UserId == id);
        }

        // Save Cart Item
        public async Task AddToCart(ShoppingCartItem item)
        {
            await _context.ShoppingCartItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task ClearCart(Customer customer)
        {
            _context.ShoppingCartItems.RemoveRange(customer.ShoppingCart.ShoppingCartItems);
            await _context.SaveChangesAsync();
        }
    }
}
