using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class Board
    {
        public static int ROWS = 6;
        public static int COLS = 7;
        char[,] GameBoard = new char[ROWS, COLS];
        public Board()
        {
            Fill();
            Display();
        }

        private void Display()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    Console.Write(GameBoard[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        private void Fill()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    GameBoard[i, j] = '*';
                }
            }
        }

        private bool IsValidMove(int col) => GameBoard[0, col] == '*' ? true : false;

        

    }
}
