using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class PlayerTurn : Turn
    {

        string mark;

        public PlayerTurn(string playerMark, Grid grid) : base(grid)
        {
            mark = playerMark;
        }

        int ReadNumber()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Select number 1-9, and press enter.");
                Console.WriteLine("");
                string input = Console.ReadLine();
                int number;
                if (int.TryParse(input, out number))

                {
                    if ((number < 1) || (number > 9))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Only accepts numbers 1-9.");
                        Console.WriteLine("");
                        continue;
                    }

                    return number;
                }

                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please enter only valid numbers.");
                    Console.WriteLine("");
                }
            }
        }

        public void PromptForMark()
        {
            Console.WriteLine("");
            Console.WriteLine(mark + "'s turn.");
            while (true)
            {
                int i = ReadNumber();
                if (PlaceMark(mark, i, ref gridState))
                {
                    return;
                }

                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("You cannot write over another person's mark. Nice try though, cheater.");
                    Console.WriteLine("If you're trying to write over your same number, you're a special kind of stupid.");
                    Console.WriteLine("");
                }
            }

        }
    }
}
