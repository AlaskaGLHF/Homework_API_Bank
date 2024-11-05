using Microsoft.EntityFrameworkCore;
using Bank.API.Interfaces;
using Bank.API.Data;
using Bank.API.Models;

namespace Bank.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankDbContext _context;

        public UserRepository(BankDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Where(u => !u.IsDeleted).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                user.DeletedAt = DateTime.UtcNow;
                await UpdateAsync(user);
            }
        }
    }
}
