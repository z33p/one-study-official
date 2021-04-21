using System;
using OneStudy.Lib.Models;
using OneStudy.Lib.Models.Abstracts;

namespace OneStudy.Lib.Contracts.Requests.Decks
{
    public class PostDeckRequest : DeckAbstract
    {
        public Deck ToDeckEntity()
        {
            var now = DateTime.UtcNow;

            var Deck = new Deck
            {
                Title = this.Title
                , Description = this.Description
                , CreatedAt = now
                , UpdatedAt = now
            };

            return Deck;
        }
    }
}