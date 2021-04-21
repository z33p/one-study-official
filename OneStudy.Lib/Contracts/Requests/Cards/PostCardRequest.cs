using System;
using OneStudy.Lib.Models;
using OneStudy.Lib.Models.Abstracts;

namespace OneStudy.Lib.Contracts.Requests.Cards
{
    public class PostCardRequest : CardAbstract
    {
        public int DeckId { get; set; }

        public Card ToCardEntity()
        {
            var now = DateTime.UtcNow;

            var card = new Card
            {
                FrontText = this.FrontText
                , BackText = this.BackText
                , CreatedAt = now
                , UpdatedAt = now
            };

            return card;
        }
    }
}