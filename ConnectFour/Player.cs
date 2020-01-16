using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class Player
    {
        public string Name { get; set; } = "";
        public char Symbol { get; set; }
        public int Turns { get; set; }

        public Player(char symbol)
        {
            GetPlayerName();
            Symbol = symbol;
        }

        public void GetPlayerName()
        {
            {
                Console.Write("Please Enter Your Name: ");
                Name = Console.ReadLine();
            }
        }
    }
}
