using Microsoft.EntityFrameworkCore;
using Bank.API.Interfaces;
using Bank.API.Models;
using Bank.API.DataContext;

namespace Bank.API.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly BankContext _context;

        public CardRepository(BankContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await _context.Cards.Where(c => !c.IsDeleted.GetValueOrDefault()).ToListAsync();
        }

        public async Task<Card?> GetByIdAsync(int id)
        {
            return await _context.Cards.FirstOrDefaultAsync(c => c.CardId == id && !c.IsDeleted.GetValueOrDefault());
        }

        public async Task AddAsync(Card card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var card = await GetByIdAsync(id);
            if (card != null)
            {
                card.IsDeleted = true;
                card.DeletedAt = DateTime.UtcNow;
                await UpdateAsync(card);
            }
        }
    }
}
