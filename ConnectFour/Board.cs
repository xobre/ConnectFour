using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConnectFour
{
    class Board
    {
        public static bool Winner = false;
        public static int NUM_TO_WIN = 4;
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

        public bool IsValidMove(int col) => GameBoard[0, col] == '*' ? true : false;

        public void Update(char symbol, int col)
        {
            int nextSpaceRow = FindNextAvailable(col);
            GameBoard[nextSpaceRow, col] = symbol;
            Winner = HasWinner(nextSpaceRow, col);
            Display();
        }

        private int FindNextAvailable(int col)
        {
            int result = -1; // Unavailable matrix location
            for (int i = ROWS - 1; i >= 0 && result == -1; i--)
            {
                if (GameBoard[i, col] == '*')
                {
                    result = i;
                }
            }
            return result;
        }

        public bool HasWinner(int lastMoveRow, int lastMoveColumn)
        {
            int lastValue = GameBoard[lastMoveRow, lastMoveColumn];
            Debug.WriteLine("drop in row: " + (lastMoveRow) + " and column: " + (lastMoveColumn) + " , the value is: " + lastValue);
            Debug.WriteLine("number of rows is " + ROWS + ", and number of colums is " + COLS);

            
            int match = 0;
            //check Horizontal
            for (int c = 0; c < COLS; c++)
            {
                int currentValue = GameBoard[lastMoveRow, c];
                if (currentValue == lastValue)
                    match++;
                else match = 0;
                if (match == NUM_TO_WIN)
                {
                    return true;
                }
            }

            match = 0;
            //check Vertical
            for (int r = 0; r < ROWS; r++)
            {
                int currentValue = GameBoard[r, lastMoveColumn];
                if (currentValue == lastValue)
                    match++;
                else match = 0;
                if (match == NUM_TO_WIN)
                {
                    return true;
                }
            }

            //check diagonal top-left to bottom-right - include middle
            match = 0;
            for (int r = 0; r <= ROWS - 4; r++)
            {
                int rowPosition = r;
                for (int column = 0; column < COLS && rowPosition < ROWS; column++)
                {
                    int currentValue = GameBoard[rowPosition, column];
                    if (currentValue == lastValue)
                        match++;
                    else match = 0;
                    if (match == NUM_TO_WIN)
                    {
                        return true;
                    }
                    rowPosition++;
                }
            }
            //check diagonal top-left to bottom-right - after middle
            match = 0;
            for (int c = 1; c <= COLS - 4; c++)
            {
                int columnPosition = c;
                for (int row = 0; row < ROWS && columnPosition < COLS; row++)
                {
                    int currentValue = GameBoard[row, columnPosition];
                    if (currentValue == lastValue)
                        match++;
                    else match = 0;
                    if (match == NUM_TO_WIN)
                    {
                        return true;
                    }
                    columnPosition++;
                }
            }
            //check diagonal bottom-left to top-right - include middle
            match = 0;
            for (int r = ROWS - 1; r >= ROWS - 4; r--)
            {
                int rowPosition = r;
                for (int column = 0; column < COLS && rowPosition < ROWS && rowPosition >= 0; column++)
                {
                    int currentValue = GameBoard[rowPosition, column];
                    if (currentValue == lastValue)
                        match++;
                    else match = 0;
                    if (match == NUM_TO_WIN)
                    {
                        return true;
                    }
                    rowPosition--;
                }
            }
            //check diagonal bottom-left to top-right - after middle
            match = 0;
            for (int c = 1; c < COLS; c++)
            {
                int columnPosition = c;
                for (int row = ROWS - 1; row < ROWS && columnPosition < COLS && columnPosition >= 1; row--)
                {
                    int currentValue = GameBoard[row, columnPosition];
                    if (currentValue == lastValue)
                        match++;
                    else match = 0;
                    if (match == NUM_TO_WIN)
                    {
                        return true;
                    }
                    columnPosition++;
                }
            }
            return false;
        }
    }
}

