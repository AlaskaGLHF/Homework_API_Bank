

using Bank.API.Interfaces;
using Bank.API.Models;

namespace Bank.API.Services
{
    public class BalanceHistoryService
    {
        private readonly IBalanceHistoryRepository _balanceHistoryRepository;

        public BalanceHistoryService(IBalanceHistoryRepository balanceHistoryRepository)
        {
            _balanceHistoryRepository = balanceHistoryRepository;
        }

        public async Task<IEnumerable<BalanceHistory>> GetBalanceHistoryByCardIdAsync(int cardId)
        {
            return await _balanceHistoryRepository.GetByCardIdAsync(cardId);
        }

        public async Task AddBalanceHistoryAsync(BalanceHistory balanceHistory)
        {
            await _balanceHistoryRepository.AddAsync(balanceHistory);
        }
    }
}
