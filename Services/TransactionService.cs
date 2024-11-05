using Bank.API.Interfaces;
using Bank.API.Models;

namespace Bank.API.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _transactionRepository.GetAllAsync();
        }

        public async Task<Transaction?> GetTransactionByIdAsync(int id)
        {
            return await _transactionRepository.GetByIdAsync(id);
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _transactionRepository.AddAsync(transaction);
        }
    }
}
