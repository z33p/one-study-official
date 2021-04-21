using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneStudy.Lib.Contracts.Requests.Cards;
using OneStudy.Lib.Contracts.Responses.Cards;
using OneStudy.Lib.Database;
using OneStudy.Lib.Models;

namespace OneStudy.Lib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly DataContext _context;

        public CardsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<IList<GetCardResponse>> GetCards()
        {
            var cards = await _context.Cards.ToListAsync();

            var cardsResponse = GetCardResponse.FromCardEntity(cards);

            return cardsResponse;
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCardResponse>> GetCard(int id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.CardId == id);

            if (card == null)
                return NotFound();

            var cardResponse = GetCardResponse.FromCardEntity(card);

            return cardResponse;
        }

        // POST: api/Cards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(PostCardRequest postCard)
        {
            var card = postCard.ToCardEntity();
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();

            var cardDeckPivot = new CardDeck();

            cardDeckPivot.CardId = card.CardId;
            cardDeckPivot.DeckId = postCard.DeckId;
 
            await _context.CardsDecks.AddAsync(cardDeckPivot);
            await _context.SaveChangesAsync();

            return Ok(card.CardId);
        }

        // PUT: api/Cards
        [HttpPut]
        public async Task<IActionResult> PutCard(PutCardRequest putCard)
        {
            var card = putCard.ToEntity();

            _context.Entry(card).State = EntityState.Modified;
            _context.Entry(card).Property(c => c.CreatedAt).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (CardExists(card.CardId))
                    throw;

                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
                return NotFound();

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardExists(int id) => _context.Cards.Any(c => c.CardId == id);
    }
}
