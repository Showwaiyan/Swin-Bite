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
                .ThenInclude(oi => oi.Food)
                .FirstOrDefaultAsync(c => c.UserId == id);
        }

        // Save Cart Item
        public async Task AddToCart(ShoppingCartItem item)
        {
            ShoppingCartItem existItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(si =>
                si.ShoppingCartId == item.ShoppingCartId && si.FoodId == item.FoodId
            );

            if (existItem != null)
                _context.ShoppingCartItems.Update(existItem);
            else
                await _context.ShoppingCartItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCart(ShoppingCartItem item)
        {
            _context.ShoppingCartItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task ClearCart(Customer customer)
        {
            _context.ShoppingCartItems.RemoveRange(customer.ShoppingCart.ShoppingCartItems);
            await _context.SaveChangesAsync();
        }
    }
}
