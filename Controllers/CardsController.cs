using Microsoft.AspNetCore.Mvc;
using Bank.API.Services;
using Bank.API.Models;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardService _cardService;

        public CardsController(CardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetAllCards()
        {
            return Ok(await _cardService.GetAllCardsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCardById(int id)
        {
            var card = await _cardService.GetCardByIdAsync(id);
            return card == null ? NotFound() : Ok(card);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCard([FromBody] Card card)
        {
            await _cardService.AddCardAsync(card);
            return CreatedAtAction(nameof(GetCardById), new { id = card.CardId }, card);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCard(int id, [FromBody] Card card)
        {
            if (id != card.CardId) return BadRequest();
            await _cardService.UpdateCardAsync(card);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCard(int id)
        {
            await _cardService.SoftDeleteCardAsync(id);
            return NoContent();
        }
    }
}
