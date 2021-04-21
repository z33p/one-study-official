using System;
using OneStudy.Lib.Models;
using OneStudy.Lib.Models.Abstracts;

namespace OneStudy.Lib.Contracts.Requests.Decks
{
    public class PutDeckRequest : DeckAbstract
    {
        public int DeckId { get; set; }
        
        public Deck ToEntity()
        {
            var deck = base.ToEntity(DeckId);

            return deck;
        }
    }
}