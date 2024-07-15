using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeNew
{
    internal class Player
    {
        private string _symbol;
        public string Symbol 
        {
            get { return _symbol; }
            set 
            {
                if (value != "o" && value != "x")
                    throw new Exception("Выберите x или o");
                _symbol = value; 
            }
        }

        private string _namePlayer;
        public string NamePlayer
        {
            get { return _namePlayer; }
            set 
            {
                if (value.Any(c => !char.IsLetter(c)))
                    throw new Exception("Имя должно содержать только английские буквы");
                _namePlayer = value; 
            }
        }

        public string[,] stepPlayer(int x, int y, Player player, string[,] array)
        {
            if (array[x, y] == "-")
            {
                array[x, y] = player.Symbol;
            }
            return array;
        }
    }
}
