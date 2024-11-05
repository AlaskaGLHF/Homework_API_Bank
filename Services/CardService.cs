using Bank.API.Interfaces;
using Bank.API.Models;

namespace Bank.API.Services
{
    public class CardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<Card>> GetAllCardsAsync()
        {
            return await _cardRepository.GetAllAsync();
        }

        public async Task<Card?> GetCardByIdAsync(int id)
        {
            return await _cardRepository.GetByIdAsync(id);
        }

        public async Task AddCardAsync(Card card)
        {
            await _cardRepository.AddAsync(card);
        }

        public async Task UpdateCardAsync(Card card)
        {
            await _cardRepository.UpdateAsync(card);
        }

        public async Task SoftDeleteCardAsync(int id)
        {
            await _cardRepository.DeleteAsync(id);
        }
    }
}
