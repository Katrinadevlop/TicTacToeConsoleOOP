using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeNew
{
    internal class Board
    {
        public void printBoard(string[,] array)
        {
            int size = 3;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($" {array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void initializeBoard(string[,] array)
        {
            int size = 3;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = "-";
                }
            }
        }

        public bool isEmptyCells(string[,] array)
        {
            int size = 3;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (array[i, j] == "-")
                        return true;
                }
            }
            return false;
        }
    }
}
