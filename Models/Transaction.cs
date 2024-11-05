using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public int? FromCardId { get; set; }
        public Card? FromCard { get; set; }

        public int? ToCardId { get; set; }
        public Card? ToCard { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public int CurrencyId { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; } = "pending";
    }
}
