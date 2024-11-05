using Bank.API.Models;


namespace Bank.API.Interfaces
{
    public interface IBalanceHistoryRepository
    {
        Task<IEnumerable<BalanceHistory>> GetByCardIdAsync(int cardId);
        Task AddAsync(BalanceHistory balanceHistory);
    }
}
