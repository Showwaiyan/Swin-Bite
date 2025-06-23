using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.Models;

namespace SwinBite.Reposiroties
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Get by id
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Get by username
        public async Task<User> GetByNameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        // Add
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        // Udpate
        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        // Delete
        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
