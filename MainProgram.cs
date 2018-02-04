using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ClassWork
{
    class MainProgram
    {
        private static bool _gameOver = false,turn = false;
        private static int _turnCount = 0;

        private static BoardModel bm;

        static void Main(string[] args)
        {
            bm = new BoardModel();

            while (!_gameOver&&_turnCount<42)
            {
                TakeTurn();
            }
            bm.DisplayBoard();

            Console.WriteLine(_turnCount > 42 ? "The game tied!" : "Congratulations! You Won!");


            Console.ReadLine();
        }

        private static void TakeTurn()
        {
            bm.DisplayBoard();
            Console.WriteLine("In which column would you like to drop a piece?");
            string input = Console.ReadLine().ToUpper();
            int colChoice = -1;
            try
            {
                char c = Char.Parse(input);
                colChoice = c - 'A';
                if (colChoice > 6 || colChoice < 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Input invalid");
                return;
            }

            bool valid = bm.DropPiece(colChoice,turn, out int row);
            if (!valid)
            {
                Console.WriteLine("Column is full");
                return;
            }

            _gameOver = bm.CheckWinner(row, colChoice);
            turn = !turn;
            _turnCount++;
            Console.WriteLine(_turnCount);
        }
    }
}
