using System;
using OneStudy.Lib.Models;
using OneStudy.Lib.Models.Abstracts;

namespace OneStudy.Lib.Contracts.Requests.Cards
{
    public class PutCardRequest : CardAbstract
    {
        public int CardId { get; set; }

        public Card ToEntity()
        {
            var card = base.ToEntity(CardId);

            card.UpdatedAt = DateTime.UtcNow;

            return card;
        }
    }
}
