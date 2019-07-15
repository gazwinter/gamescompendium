
using Xamarin.Forms;

namespace GamesCompendium.ViewModels
{
    public class CardGamesViewModel : BaseViewModel
    {
        
        public CardGamesViewModel()
        {
            Title = "Card Games";
            LoadGameCommand = new Command<string>(LoadCardGame);
            
        }

        private async void LoadCardGame(string game)
        {
            switch (game)
            {
                case "Blackjack":
                    await Shell.Current.GoToAsync("\\Blackjack");
                    break;
                default:
                    break;
            }   
        }
    }
}