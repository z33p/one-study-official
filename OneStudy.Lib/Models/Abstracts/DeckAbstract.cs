using System;

namespace OneStudy.Lib.Models.Abstracts
{
    public abstract class DeckAbstract
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Deck ToEntity(int deckId)
        {
            var deck = new Deck(deckId, Title, Description);

            deck.UpdatedAt = DateTime.UtcNow;

            return deck;
        }
    }
}
