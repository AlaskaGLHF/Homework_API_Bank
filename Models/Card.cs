using Bank.API.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Required, MaxLength(16)]
        public string CardNumber { get; set; }

        [Required]
        public string CardType { get; set; } // e.g., 'debit' or 'credit'

        [Required]
        public DateTime ExpirationDate { get; set; }

        public decimal Balance { get; set; } = 0.00m;
        public int CurrencyId { get; set; }
        public decimal CreditLimit { get; set; } = 0.00m;

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}
