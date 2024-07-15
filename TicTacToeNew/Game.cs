using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeNew
{
    internal class Game
    {

        public bool chekStep(int x, int y)
        {
            if (x <= 3 && y <= 3 && x >= 1 && y >= 1)
                return true;
            else
                return false;
        }

        public bool checkWhyWin(string symbol, string[,] array)
        {
            int size = 3;
            bool isWin;

            // Проверка строк
            for (int i = 0; i < size; i++)
            {
                isWin = true;
                for (int j = 0; j < size; j++)
                {
                    if (array[i, j] != symbol)
                    {
                        isWin = false;
                        break;
                    }
                }
                if (isWin)
                    return true;
            }

            // Проверка столбцов
            for (int i = 0; i < size; i++)
            {
                isWin = true;
                for (int j = 0; j < size; j++)
                {
                    if (array[j, i] != symbol)
                    {
                        isWin = false;
                        break;
                    }
                }
                if (isWin)
                    return true;
            }

            // Проверка главной диагонали
            isWin = true;
            for (int i = 0; i < size; i++)
            {
                if (array[i, i] != symbol)
                {
                    isWin = false;
                    break;
                }
            }
            if (isWin)
                return true;

            // Проверка побочной диагонали
            isWin = true;
            for (int i = 0; i < size; i++)
            {
                if (array[i, size - i - 1] != symbol)
                {
                    isWin = false;
                    break;
                }
            }
            if (isWin)
                return true;

            return false;
        }

        public bool chekDraw(bool ifChekWin)
        {
            int size = 3;
            bool isWin = false;
            for (int i = 0; i < size; i++)
            {
                isWin = false;
                for (int j = 0; j < size; j++)
                {
                    if (ifChekWin)
                        isWin = true;
                }
            }
            return isWin;
        }
    }
}
