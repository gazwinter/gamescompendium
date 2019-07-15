using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using GamesCompendium.Models;
using GamesCompendium.Views;

namespace GamesCompendium.ViewModels
{
    public class ClassicGamesViewModel : BaseViewModel
    {
        
        public ClassicGamesViewModel()
        {
            Title = "Classic Games";
            LoadGameCommand = new Command<string>(LoadClassicGame);
            
        }

        private async void LoadClassicGame(string game)
        {
            switch (game)
            {
                case "TicTacToe":
                    await Shell.Current.GoToAsync("\\TicTacToe");
                    break;
                default:
                    break;
            }   
        }
    }
}