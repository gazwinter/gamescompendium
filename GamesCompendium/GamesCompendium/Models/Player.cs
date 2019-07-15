using System;
using System.Collections.Generic;
using System.Text;

namespace GamesCompendium.Models
{
    public class Player
    {
        public string Name { get; set; }
        public char Symbol { get; set; }
        public bool IsPlayerTurn { get; set; }
    }
}
