using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Turn
    {

        protected Grid gridState;

        public Turn(Grid grid)
        {
            gridState = grid;
        }

        void PrintSlot(int x, int y, Grid grid)
        {
            if (grid[x, y] == "X")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (grid[x, y] == "O")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(grid[x, y]);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void PrintGrid(Grid grid) //Error
        {
            string output = string.Format("_{0}_|_{1}_|_{2}_\n_{3}_|_{4}_|_{5}_\n {6} | {7} | {8} ", grid[0, 0], grid[1, 0], grid[2, 0],
                grid[0, 1], grid[1, 1], grid[2, 1], grid[0, 2], grid[1, 2], grid[2, 2]); // { } is a Token

            // Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("_");
            PrintSlot(0, 0, grid);
            Console.Write("_|_");
            PrintSlot(1, 0, grid);
            Console.Write("_|_");
            PrintSlot(2, 0, grid);
            Console.Write("_ \n");

            Console.Write("_");
            PrintSlot(0, 1, grid);
            Console.Write("_|_");
            PrintSlot(1, 1, grid);
            Console.Write("_|_");
            PrintSlot(2, 1, grid);
            Console.Write("_ \n");

            Console.Write(" ");
            PrintSlot(0, 2, grid);
            Console.Write(" | ");
            PrintSlot(1, 2, grid);
            Console.Write(" | ");
            PrintSlot(2, 2, grid);
            Console.Write(" \n");

            //Console.WriteLine(output);

            Console.ResetColor();
        }

        public bool PlaceMark(string mark, int slot, ref Grid grid) //Does this write X,O in the slot, can't read that it does. ref passes by reference 
        {

            switch (slot) //Defines cases. Cleaner way of writing "ifs"
            {
                case 1:
                    if (grid[0, 0].Contains("1"))
                    {
                        grid[0, 0] = mark;
                        return true;
                    }
                    break;

                case 2:
                    if (grid[1, 0].Contains("2"))
                    {
                        grid[1, 0] = mark;
                        return true;
                    }
                    break;

                case 3:
                    if (grid[2, 0].Contains("3"))
                    {
                        grid[2, 0] = mark;
                        return true;
                    }
                    break;

                case 4:
                    if (grid[0, 1].Contains("4"))
                    {
                        grid[0, 1] = mark;
                        return true;
                    }
                    break;

                case 5:
                    if (grid[1, 1].Contains("5"))
                    {
                        grid[1, 1] = mark;
                        return true;
                    }
                    break;

                case 6:
                    if (grid[2, 1].Contains("6"))
                    {
                        grid[2, 1] = mark;
                        return true;
                    }
                    break;

                case 7:
                    if (grid[0, 2].Contains("7"))
                    {
                        grid[0, 2] = mark;
                        return true;
                    }
                    break;


                case 8:
                    if (grid[1, 2].Contains("8"))
                    {
                        grid[1, 2] = mark;
                        return true;
                    }
                    break;

                case 9:
                    if (grid[2, 2].Contains("9"))
                    {
                        grid[2, 2] = mark;
                        return true;
                    }
                    break;

                default: //If you reach me, then do next:
                    break;
            }

            return false;
        }

    }
}
