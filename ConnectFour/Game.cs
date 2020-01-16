using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class Game
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public Player ActivePlayer { get; set; }
        public Board Board { get; set; }

        public Game()
        {
            PlayerOne = new Player('O'); 
            PlayerTwo = new Player('X'); 
            ActivePlayer = PlayerOne;
            Board = new Board();
        }

        public void Start()
        {
            Console.Clear();
            while (!Board.Winner)
            {
                TakeTurn();
            }
        }

        private void TakeTurn() 
        {
            // Ask user for COL
            bool isNum = false;
            bool isValidMove = false;
            int selectedCOL = 0;
            while (!isValidMove)
            {
                Console.Write("Select a column 1 - 7 : ");
                isNum = int.TryParse(Console.ReadLine(), out selectedCOL);
            // Valid user input (isValidMove)
                if (isNum && selectedCOL < 8 && selectedCOL > 0)
                {
                    selectedCOL -= 1; // Converting user input to zero based index
                    isValidMove = Board.IsValidMove(selectedCOL); 
                }
                else if (!isNum)
                {
                    Console.WriteLine("Invalid Number");
                }
                else {
                    Console.WriteLine("Column Full");
                }
            }
            // Update Board
            Board.Update(ActivePlayer.Symbol, selectedCOL);
            // Change active player
            ActivePlayer = ActivePlayer == PlayerOne ? PlayerTwo : PlayerOne;
        }
    }
}
