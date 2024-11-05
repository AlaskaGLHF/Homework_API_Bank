﻿using Microsoft.EntityFrameworkCore;
using Bank.API.Models;
using Bank.API.Interfaces;
using Bank.API.Data;

namespace Bank.API.Repositories
{
    public class BalanceHistoryRepository : IBalanceHistoryRepository
    {
        private readonly BankDbContext _context;

        public BalanceHistoryRepository(BankDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BalanceHistory>> GetByCardIdAsync(int cardId)
        {
            return await _context.BalanceHistories
                .Where(bh => bh.CardId == cardId)
                .ToListAsync();
        }

        public async Task AddAsync(BalanceHistory balanceHistory)
        {
            await _context.BalanceHistories.AddAsync(balanceHistory);
            await _context.SaveChangesAsync();
        }
    }
}