using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class Player
    {
        public string Name { get; set; }
        public char Symbol { get; set; }
        public int Turns { get; set; }

        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
