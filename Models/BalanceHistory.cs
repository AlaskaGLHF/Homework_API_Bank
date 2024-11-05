using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Models
{
    public class BalanceHistory
    {
        public int BalanceHistoryId { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
    }
}
