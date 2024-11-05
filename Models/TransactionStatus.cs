using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TransactionStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
