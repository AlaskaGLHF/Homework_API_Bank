using Microsoft.AspNetCore.Mvc;
using Bank.API.Services;
using Bank.API.Models;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceHistoryController : ControllerBase
    {
        private readonly BalanceHistoryService _balanceHistoryService;

        public BalanceHistoryController(BalanceHistoryService balanceHistoryService)
        {
            _balanceHistoryService = balanceHistoryService;
        }

        [HttpGet("card/{cardId}")]
        public async Task<ActionResult<IEnumerable<BalanceHistory>>> GetBalanceHistoryByCardId(int cardId)
        {
            var history = await _balanceHistoryService.GetBalanceHistoryByCardIdAsync(cardId);
            return Ok(history);
        }

        [HttpPost]
        public async Task<ActionResult> AddBalanceHistory([FromBody] BalanceHistory balanceHistory)
        {
            await _balanceHistoryService.AddBalanceHistoryAsync(balanceHistory);
            return CreatedAtAction(nameof(GetBalanceHistoryByCardId), new { cardId = balanceHistory.CardId }, balanceHistory);
        }
    }
}
