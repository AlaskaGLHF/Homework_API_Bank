using Microsoft.AspNetCore.Mvc;
using Bank.API.Services;
using Bank.API.Models;


namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionsController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetAllTransactions()
        {
            return Ok(await _transactionService.GetAllTransactionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            return transaction == null ? NotFound() : Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransaction([FromBody] Transaction transaction)
        {
            await _transactionService.AddTransactionAsync(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.TransactionId }, transaction);
        }
    }
}
