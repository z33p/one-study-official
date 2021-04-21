using System;
using System.Collections.Generic;
using System.Linq;
using OneStudy.Core.Models.Interfaces;
using OneStudy.Lib.Contracts.Responses.Cards;
using OneStudy.Lib.Models;
using OneStudy.Lib.Models.Abstracts;

namespace OneStudy.Lib.Contracts.Responses.Decks
{
    public class GetDeckResponse : DeckAbstract, IOneModel
    {
        public int DeckId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public IList<GetCardResponse> Cards { get; set; }

        public static GetDeckResponse FromDeckEntity(Deck deck)
        {
            var deckResponse = new GetDeckResponse
            {
                DeckId = deck.DeckId
                , Title = deck.Title
                , Description = deck.Description

                , CreatedAt = deck.CreatedAt
                , UpdatedAt = deck.UpdatedAt

                , Cards = deck.CardDecks.Select(cd => GetCardResponse.FromCardEntity(cd.Card)).ToList()
            };

            return deckResponse;
        }

        public static IList<GetDeckResponse> FromDeckEntity(List<Deck> decks) => decks.Select(d => GetDeckResponse.FromDeckEntity(d)).ToList();
    }
}