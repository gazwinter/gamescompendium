using GamesCompendium.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesCompendium.Models
{
    public class Card
    {
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }

        public string ImageName { get; set; }

        public Card(CardRank rank, CardSuit suit, string name)
        {
            Rank = rank;
            Suit = suit;
            ImageName = name;
        }
    }
}
