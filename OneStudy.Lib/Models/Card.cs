using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OneStudy.Core.Models.Interfaces;
using OneStudy.Lib.Models.Abstracts;

namespace OneStudy.Lib.Models
{
    public class Card : CardAbstract, IOneModel
    {
        [Key]
        public int CardId { get; set; }

        public IList<CardDeck> CardDecks { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Card() {}

        public Card(int cardId, string frontText, string backText)
        {
            CardId = cardId;
            FrontText = frontText;
            BackText = backText;
        }
    }
}
