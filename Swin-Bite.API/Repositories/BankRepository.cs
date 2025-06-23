using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.Models;

namespace SwinBite.Reposiroties
{
    public class BankRepository
    {
        private readonly AppDbContext _context;

        public BankRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BankAccount> GetByIdAsync(int id)
        {
            return await _context
                .BankAccounts.Include(b => b.User)
                .FirstOrDefaultAsync(b => b.BankId == id);
        }

        public async Task UpdateBankAccount(BankAccount account)
        {
            _context.BankAccounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
