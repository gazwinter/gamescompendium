using GamesCompendium.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GamesCompendium
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("TicTacToe", typeof(TicTacToePage));
            Routing.RegisterRoute("Blackjack", typeof(BlackjackPage));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Routing.UnRegisterRoute("TicTacToe");
            Routing.UnRegisterRoute("Blackjack");
        }
    }
}
