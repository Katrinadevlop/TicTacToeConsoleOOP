using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeNew
{
    internal class Program
    {
        public static string namePlayerFun(Player player)
        {
            bool validName = false;
            while (!validName)
            {
                Console.WriteLine("Введите ваше имя: ");

                try
                {
                    player.NamePlayer = Console.ReadLine();
                    validName = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return player.NamePlayer;
        }

        public static string chooseSymbol(Player player)
        {
            bool validSymbol = false;
            while (!validSymbol)
            {
                Console.WriteLine("Выберите символ для игры (x,o): ");

                try
                {
                    player.Symbol = Console.ReadLine();
                    validSymbol = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return player.Symbol;
        }

        public static void gameMain(Board board, Bot bot, Game game, Player player)
        {
            string[,] array = new string[3, 3];
            bool win = false;
            board.initializeBoard(array);
            while (board.isEmptyCells(array) && !win)
            {
                int x = 0, y = 0;
                bool validStep = false;

                while (!validStep)
                {
                    Console.WriteLine("Введите координаты (1 2): ");
                    string[] step = Console.ReadLine().Split(' ');
                    bool validStepXY = false;
                    while (!validStepXY)
                    {
                        try
                        {
                            x = Convert.ToInt32(step[0]);
                            y = Convert.ToInt32(step[1]);
                            validStepXY = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }

                        validStep = game.chekStep(x, y);


                        if (!validStep)
                        {
                            Console.WriteLine("Некорректные координаты");
                        }
                    }
                }

                x--;
                y--;

                array = player.stepPlayer(x, y, player, array);
                bool chekWinPlayer = game.checkWhyWin(player.Symbol, array);
                if (chekWinPlayer == true)
                {
                    Console.WriteLine($"{player.NamePlayer} победил!");
                    board.printBoard(array);
                    win = true;
                    break;
                }

                if (!board.isEmptyCells(array))
                    break;

                array = bot.stepBot(player, array);
                chekWinPlayer = game.checkWhyWin(bot.Symbol, array);
                if (chekWinPlayer == true)
                {
                    Console.WriteLine("Бот победил!");
                    win = true;
                    break;
                }

                if (!board.isEmptyCells(array) && game.chekDraw(chekWinPlayer))
                {
                    Console.WriteLine("Ничья!");
                    break;
                }
                board.printBoard(array);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Board board = new Board();
            Player player = new Player();
            Bot bot = new Bot();
            Game game = new Game();

            Console.WriteLine("Это игра крестики нолики!");

            string namePlayer = namePlayerFun(player);
            string symbol = chooseSymbol(player);

            gameMain(board, bot, game, player);
            Console.ReadLine();
        }
    }
}
