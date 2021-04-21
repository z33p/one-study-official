using System;
using System.Collections.Generic;
using System.Linq;
using OneStudy.Core.Models.Interfaces;
using OneStudy.Lib.Models;
using OneStudy.Lib.Models.Abstracts;

namespace OneStudy.Lib.Contracts.Responses.Cards
{
    public class GetCardResponse : CardAbstract, IOneModel
    {
        public int CardId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static GetCardResponse FromCardEntity(Card card)
        {
            var cardResponse = new GetCardResponse
            {
                CardId = card.CardId
                , FrontText = card.FrontText
                , BackText = card.BackText

                , CreatedAt = card.CreatedAt
                , UpdatedAt = card.UpdatedAt
            };

            return cardResponse;
        }

        public static IList<GetCardResponse> FromCardEntity(IList<Card> cards) => cards.Select(c => GetCardResponse.FromCardEntity(c)).ToList();
    }
}