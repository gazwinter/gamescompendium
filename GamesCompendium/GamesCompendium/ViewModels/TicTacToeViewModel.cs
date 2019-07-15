using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GamesCompendium.Models;
using Xamarin.Forms;

namespace GamesCompendium.ViewModels
{
    public class TicTacToeViewModel : BaseViewModel
    {
        #region Private Members
        private string _button1Text;
        private string _button2Text;
        private string _button3Text;
        private string _button4Text;
        private string _button5Text;
        private string _button6Text;
        private string _button7Text;
        private string _button8Text;
        private string _button9Text;
        //private string _currentPlayerText;
        //private string _winningPlayerMessage;
        private Player _currentPlayer;
        

        private bool _button1Enabled;
        private bool _button2Enabled;
        private bool _button3Enabled;
        private bool _button4Enabled;
        private bool _button5Enabled;
        private bool _button6Enabled;
        private bool _button7Enabled;
        private bool _button8Enabled;
        private bool _button9Enabled;
        private bool _showWinningMessage;
        private bool _showDrawMessage;
        private bool _gameEnded;
        #endregion

        #region Public Properties
        public bool ShowWinningMessage
        {
            get
            {
                return _showWinningMessage;
            }
            set
            {
                _showWinningMessage = value;
                OnPropertyChanged(nameof(ShowWinningMessage));
            }
        }

        public bool ShowDrawMessage
        {
            get
            {
                return _showDrawMessage;
            }
            set
            {
                _showDrawMessage = value;
                OnPropertyChanged(nameof(ShowDrawMessage));
            }
        }
        public bool GameEnded
        {
            get
            {
                return _gameEnded;
            }
            set
            {
                _gameEnded = value;
                OnPropertyChanged(nameof(GameEnded));
            }
        }


        public string DrawMessage
        {
            get
            {
                return "The game has ended in a draw";
            }
        }
        public string WinningPlayerMessage
        {
            get
            {
                return $"The winner is {CurrentPlayer.Name}";
            }
        }
        public string CurrentPlayerText
        {
            get
            {
                return $"Current player: {CurrentPlayer.Name}";
            }
        }
        public bool Button1Enabled
        {
            get
            {
                return _button1Enabled;
            }
            set
            {
                _button1Enabled = value;
                OnPropertyChanged(nameof(Button1Enabled));
            }
        }

        

        public bool Button2Enabled
        {
            get
            {
                return _button2Enabled;
            }
            set
            {
                _button2Enabled = value;
                OnPropertyChanged(nameof(Button2Enabled));
            }
        }

        public bool Button3Enabled
        {
            get
            {
                return _button3Enabled;
            }
            set
            {
                _button3Enabled = value;
                OnPropertyChanged(nameof(Button3Enabled));
            }
        }

        public bool Button4Enabled
        {
            get
            {
                return _button4Enabled;
            }
            set
            {
                _button4Enabled = value;
                OnPropertyChanged(nameof(Button4Enabled));
            }
        }

        public bool Button5Enabled
        {
            get
            {
                return _button5Enabled;
            }
            set
            {
                _button5Enabled = value;
                OnPropertyChanged(nameof(Button5Enabled));
            }
        }

        public bool Button6Enabled
        {
            get
            {
                return _button6Enabled;
            }
            set
            {
                _button6Enabled = value;
                OnPropertyChanged(nameof(Button6Enabled));
            }
        }

        public bool Button7Enabled
        {
            get
            {
                return _button7Enabled;
            }
            set
            {
                _button7Enabled = value;
                OnPropertyChanged(nameof(Button7Enabled));
            }
        }

        public bool Button8Enabled
        {
            get
            {
                return _button8Enabled;
            }
            set
            {
                _button8Enabled = value;
                OnPropertyChanged(nameof(Button8Enabled));
            }
        }

        public bool Button9Enabled
        {
            get
            {
                return _button9Enabled;
            }
            set
            {
                _button9Enabled = value;
                OnPropertyChanged(nameof(Button9Enabled));
            }
        }
        List<Player> Players { get; set; }
        public Player CurrentPlayer
        {
            get
            {
                return _currentPlayer;
            }
            set
            {
                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
                OnPropertyChanged(nameof(WinningPlayerMessage));
                OnPropertyChanged(nameof(CurrentPlayerText));
            }
        }

        public string Button1Text
        {
            get
            {
                return _button1Text;
            }
            set
            {
                _button1Text = value;
                OnPropertyChanged(nameof(Button1Text));
            }
        }

        public string Button2Text
        {
            get
            {
                return _button2Text;
            }
            set
            {
                _button2Text = value;
                OnPropertyChanged(nameof(Button2Text));
            }
        }

        public string Button3Text
        {
            get
            {
                return _button3Text;
            }
            set
            {
                _button3Text = value;
                OnPropertyChanged(nameof(Button3Text));
            }
        }

        public string Button4Text
        {
            get
            {
                return _button4Text;
            }
            set
            {
                _button4Text = value;
                OnPropertyChanged(nameof(Button4Text));
            }
        }

        public string Button5Text
        {
            get
            {
                return _button5Text;
            }
            set
            {
                _button5Text = value;
                OnPropertyChanged(nameof(Button5Text));
            }
        }

        public string Button6Text
        {
            get
            {
                return _button6Text;
            }
            set
            {
                _button6Text = value;
                OnPropertyChanged(nameof(Button6Text));
            }
        }

        public string Button7Text
        {
            get
            {
                return _button7Text;
            }
            set
            {
                _button7Text = value;
                OnPropertyChanged(nameof(Button7Text));
            }
        }

        public string Button8Text
        {
            get
            {
                return _button8Text;
            }
            set
            {
                _button8Text = value;
                OnPropertyChanged(nameof(Button8Text));
            }
        }

        public string Button9Text
        {
            get
            {
                return _button9Text;
            }
            set
            {
                _button9Text = value;
                OnPropertyChanged(nameof(Button9Text));
            }
        }
        #endregion

        public ICommand ButtonClickedCommand { get; set; }
        public ICommand ResetGameCommand { get; set; }

        public TicTacToeViewModel()
        {
            ButtonClickedCommand = new Command<string>(GridButtonPressed);
            ResetGameCommand = new Command(ResetGame);
            ResetGame(null);            
        }

        private void ResetGame(object obj)
        {
            SetupPlayers();
            ResetGrid();
        }

        private void CheckForWinner()
        {
            
            if(((Button1Text == Button2Text && Button2Text == Button3Text) && !String.IsNullOrEmpty(Button1Text)) ||
                ((Button4Text == Button5Text && Button5Text == Button6Text) && !String.IsNullOrEmpty(Button4Text)) ||
                ((Button7Text == Button8Text && Button8Text == Button9Text) && !String.IsNullOrEmpty(Button7Text))||
                ((Button1Text == Button4Text && Button4Text == Button7Text) && !String.IsNullOrEmpty(Button1Text))||
                ((Button2Text == Button5Text && Button5Text == Button8Text) && !String.IsNullOrEmpty(Button2Text))||
                ((Button3Text == Button6Text && Button6Text == Button9Text) && !String.IsNullOrEmpty(Button3Text))||
                ((Button1Text == Button5Text && Button5Text == Button9Text) && !String.IsNullOrEmpty(Button1Text))||
                ((Button3Text == Button5Text && Button5Text == Button7Text) && !String.IsNullOrEmpty(Button3Text))
                )
            {
                GameEnded = true;
                ShowWinningMessage = true;
            }
            else if(!Button1Enabled && !Button2Enabled && !Button3Enabled && !Button4Enabled && !Button5Enabled && !Button6Enabled && !Button7Enabled && !Button8Enabled && !Button9Enabled)
            {
                ShowDrawMessage = true;
                GameEnded = true;
            }
        }

        private void ResetGrid()
        {
            Button1Enabled = true;
            Button1Text = "";

            Button2Enabled = true;
            Button2Text = "";

            Button3Enabled = true;
            Button3Text = "";

            Button4Enabled = true;
            Button4Text = "";

            Button5Enabled = true;
            Button5Text = "";

            Button6Enabled = true;
            Button6Text = "";

            Button7Enabled = true;
            Button7Text = "";

            Button8Enabled = true;
            Button8Text = "";

            Button9Enabled = true;
            Button9Text = "";

            
        }

        private void SetupPlayers()
        {
            Players = new List<Player>
            {
                new Player { Name = "Player 1", IsPlayerTurn = true, Symbol = 'O' },
                new Player { Name = "Player 2", IsPlayerTurn = false, Symbol = 'X' }
            };

            CurrentPlayer = Players.First(x => x.IsPlayerTurn);

            ShowWinningMessage = false;
            ShowDrawMessage = false;
            GameEnded = false;
        }

        private void GridButtonPressed(string name)
        {
            //var btn = obj as Xamarin.Forms.Button;
            //var name = btn.Text;
            if (!GameEnded)
            {
                UpdateGrid(name, CurrentPlayer.Symbol);
            }
            
            CheckForWinner();

            if (!GameEnded)
            {
                ChangePlayer();
            }
            
        }

        private void ChangePlayer()
        {
            var playerName = CurrentPlayer.Name;

            Players.ForEach(x =>
            {
                if (x.Name == playerName)
                {
                    x.IsPlayerTurn = false;
                }
                else
                {
                    x.IsPlayerTurn = true;
                }
            });

            CurrentPlayer = Players.First(x => x.IsPlayerTurn);

        }

        private void UpdateGrid(string buttonName, char symbol)
        {
            switch (buttonName)
            {
                case "Button1":
                    Button1Text = symbol.ToString();
                    Button1Enabled = false;
                    break;
                case "Button2":
                    Button2Text = symbol.ToString();
                    Button2Enabled = false;
                    break;
                case "Button3":
                    Button3Text = symbol.ToString();
                    Button3Enabled = false;
                    break;
                case "Button4":
                    Button4Text = symbol.ToString();
                    Button4Enabled = false;
                    break;
                case "Button5":
                    Button5Text = symbol.ToString();
                    Button5Enabled = false;
                    break;
                case "Button6":
                    Button6Text = symbol.ToString();
                    Button6Enabled = false;
                    break;
                case "Button7":
                    Button7Text = symbol.ToString();
                    Button7Enabled = false;
                    break;
                case "Button8":
                    Button8Text = symbol.ToString();
                    Button8Enabled = false;
                    break;
                case "Button9":
                    Button9Text = symbol.ToString();
                    Button9Enabled = false;
                    break;
            }
        }
    }
}
