using GamesCompendium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesCompendium.ViewModels
{
    public class BlackjackViewModel : BaseViewModel
    {
        private int _dealersHandValue;
        private int _playersHandValue;

        public int DealersHandValue
        {
            get
            {
                return _dealersHandValue;
            }

            set
            {
                SetProperty(ref _dealersHandValue, value);
            }
        }

        public int PlayersHandValue
        {
            get
            {
                return _playersHandValue;
            }

            set
            {
                SetProperty(ref _playersHandValue, value);
            }
        }

        public CardDeck Deck {get;set;}

        public List<Card> DealersHand { get; set; }
        
        public List<Card> PlayersHand { get; set; }

        public BlackjackViewModel()
        {
            Deck = new CardDeck();
            PlayersHand = new List<Card>();
            DealersHand = new List<Card>();
            Deal();
        }

        private void Deal()
        {
            //First Card
            PlayersHand.Add(GetNextCard());
            DealersHand.Add(GetNextCard());

            //Second Card
            PlayersHand.Add(GetNextCard());
            DealersHand.Add(GetNextCard());

            CalculateHandValues();
        }

        private void CalculateHandValues()
        {
            PlayersHandValue = PlayersHand.Sum(x => (int)x.Rank);
            DealersHandValue = DealersHand.Sum(x => (int)x.Rank);
        }

        private Card GetNextCard()
        {
            var card = Deck.ShuffledDeck.First();
            Deck.ShuffledDeck.Remove(card);
            return card;
        }
    }
}
