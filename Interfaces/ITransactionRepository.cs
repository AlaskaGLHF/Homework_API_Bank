using Bank.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.API.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int id);
        Task AddAsync(Transaction transaction);
    }
}
