namespace OneStudy.Lib.Models
{
    public class CardDeck
    {
        public int CardId { get; set; }
        public Card Card { get; set; }

        public int DeckId { get; set; }
        public Deck Deck { get; set; }

    }
}
