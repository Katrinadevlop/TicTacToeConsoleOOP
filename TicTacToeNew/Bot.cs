using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeNew
{
    internal class Bot
    {
        private string _symbol;
        public string Symbol { get; set; }

        public string[,] stepBot(Player player, string[,] array) 
        { 
            if (player.Symbol == "x") Symbol = "o";
            else Symbol = "x";

            int size = 3;
            bool isStep = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (!isStep && array[i,j] == "-")
                    {
                        array[i, j] = Symbol;
                        isStep = true;
                    }
                }
            }
            return array;
        }
    }
}
