using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneStudy.Lib.Contracts.Requests.Decks;
using OneStudy.Lib.Contracts.Responses.Cards;
using OneStudy.Lib.Contracts.Responses.Decks;
using OneStudy.Lib.Database;
using OneStudy.Lib.Models;

namespace OneStudy.Lib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecksController : ControllerBase
    {
        private readonly DataContext _context;

        public DecksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Decks
        [HttpGet]
        public async Task<IList<GetDeckResponse>> GetDecks()
        {
            var decks = await _context.Decks
                .Include(d => d.CardDecks)
                .ThenInclude(cd => cd.Card)
                .ToListAsync();

            var decksResponse = GetDeckResponse.FromDeckEntity(decks);

            return decksResponse;
        }

        // GET: api/Decks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetDeckResponse>> GetDeck(int id)
        {
            var deck = await _context.Decks
                .Include(d => d.CardDecks)
                .ThenInclude(cd => cd.Card)
                .FirstOrDefaultAsync(d => d.DeckId == id);

            if (deck == null)
                return NotFound();

            var deckResponse = GetDeckResponse.FromDeckEntity(deck);

            return deckResponse;
        }

        // POST: api/Decks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deck>> PostDeck(PostDeckRequest postDeck)
        {
            var deck = postDeck.ToDeckEntity();

            _context.Decks.Add(deck);
            await _context.SaveChangesAsync();

            return Ok(deck.DeckId);
        }
        
        // PUT: api/Decks
        [HttpPut]
        public async Task<IActionResult> PutDeck(int id, PutDeckRequest putDeck)
        {
            var deck = putDeck.ToEntity();

            _context.Entry(deck).State = EntityState.Modified;
            _context.Entry(deck).Property(d => d.CreatedAt).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (DeckExists(id))
                    throw;
                
                return NotFound();
            }

            return NoContent();
        }


        // DELETE: api/Decks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeck(int id)
        {
            var deck = await _context.Decks.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }

            _context.Decks.Remove(deck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeckExists(int id)
        {
            return _context.Decks.Any(e => e.DeckId == id);
        }
    }
}
