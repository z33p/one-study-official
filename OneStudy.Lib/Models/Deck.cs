using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OneStudy.Core.Models.Interfaces;
using OneStudy.Lib.Models.Abstracts;

namespace OneStudy.Lib.Models
{
    public class Deck : DeckAbstract, IOneModel
    {
        [Key]
        public int DeckId { get; set; }
        
        public IList<CardDeck> CardDecks { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Deck() {}
        public Deck(int deckId, string title, string description)
        {
            DeckId = deckId;
            Title = title;
            Description = description;
        }
    }
}
