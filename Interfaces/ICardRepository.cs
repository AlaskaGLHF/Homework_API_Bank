using Bank.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.API.Interfaces
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetAllAsync();
        Task<Card?> GetByIdAsync(int id);
        Task AddAsync(Card card);
        Task UpdateAsync(Card card);
        Task DeleteAsync(int id);
    }
}
