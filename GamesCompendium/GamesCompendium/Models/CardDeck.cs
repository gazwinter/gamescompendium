using GamesCompendium.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesCompendium.Models
{
    public class CardDeck
    {
        private Card[] Cards {get;set;}

        public List<Card> ShuffledDeck { get; set; }

        public CardDeck()
        {            
            CreateDeck();
            ShuffleDeck();
        }

        private void ShuffleDeck()
        {
            var rand = new Random();

            Card temp = null;

            for (int i = 0; i < 100; i++)
            {
                int card = rand.Next(52);
                int card2 = rand.Next(52);

                temp = Cards[card];
                Cards[card] = Cards[card2];
                Cards[card2] = temp;
            }

            ShuffledDeck = Cards.ToList();
        }

        private void CreateDeck()
        {
            var card = 0;
            Cards = new Card[52];
            foreach (var suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach(var rank in Enum.GetValues(typeof(CardRank)))
                {
                    var cardImage = String.Concat(rank.ToString(), suit.ToString(), ".png");
                    Cards[card] = new Card((CardRank)rank, (CardSuit)suit, cardImage);
                    card++;
                }
            }
        }
    }
}
