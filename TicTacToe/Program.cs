using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe //Create Tic Tac Toe game with 2 players
                    /* 
                    1) Every turn you draw out the console grid.
                    2) Randomly pick, a starting player. IE X player or O player
                    3) Ask player where to mark - (or if they're trying to mark something already invalid)
                    4) Update grid (Draw X's and O's)
                    5) Check for win/stalemate
                    Repeat 3-5
                    */

/*
    _[0],[0]_|_[0],[1]_|_[0],[2]_
    _4_|_5_|_6_
    _7_|_8_|_9_

*/

/*
    2 Dimensional Array
*/
{
    class Program
    {
        static string[,] grid;

        static string currentPlayer;

        static void PrintSlot(int x, int y)
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

        static void PrintGrid() //Error
        {
            string output = string.Format("_{0}_|_{1}_|_{2}_\n_{3}_|_{4}_|_{5}_\n {6} | {7} | {8} ", grid[0, 0], grid[1, 0], grid[2, 0],
                grid[0, 1], grid[1, 1], grid[2, 1], grid[0, 2], grid[1, 2], grid[2, 2]); // { } is a Token

            // Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("_");
            PrintSlot(0, 0);
            Console.Write("_|_");
            PrintSlot(1, 0);
            Console.Write("_|_");
            PrintSlot(2, 0);
            Console.Write("_ \n");

            Console.Write("_");
            PrintSlot(0, 1);
            Console.Write("_|_");
            PrintSlot(1, 1);
            Console.Write("_|_");
            PrintSlot(2, 1);
            Console.Write("_ \n");

            Console.Write(" ");
            PrintSlot(0, 2);
            Console.Write(" | ");
            PrintSlot(1, 2);
            Console.Write(" | ");
            PrintSlot(2, 2);
            Console.Write(" \n");

            //Console.WriteLine(output);

            Console.ResetColor();
        }

        static void PlayerSelector()
        {
            Random rnd = new Random();
            int s = rnd.Next(1, 3); //MinValue is inclusive, MaxValue is exclusive... bastards.

            if (s == 1)
            {
                currentPlayer = "X";
            }

            else if (s == 2)
            {
                currentPlayer = "O";
            }
        }

        static int ReadNumber()
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

        static void CreateGrid() //Initializer function
        {
            grid = new string[3, 3];
            grid[0, 0] = "1";
            grid[1, 0] = "2";
            grid[2, 0] = "3";
            grid[0, 1] = "4";
            grid[1, 1] = "5";
            grid[2, 1] = "6";
            grid[0, 2] = "7";
            grid[1, 2] = "8";
            grid[2, 2] = "9";
        }

        static bool PlaceMark(string mark, int slot) //Does this write X,O in the slot, can't read that it does.
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

        static void PlayerTurn()
        {
            Console.WriteLine("");
            Console.WriteLine(currentPlayer + "'s turn.");
            while (true)
            {
                int i = ReadNumber();
                if (PlaceMark(currentPlayer, i))
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

        static bool WinCondition()
        {
            string mark = currentPlayer;

            // First Row
            if (grid[0, 0] == mark && grid[1, 0] == mark && grid[2, 0] == mark)
            {
                return true;
            }

            //Second Row
            if (grid[0, 1] == mark && grid[1, 1] == mark && grid[2, 1] == mark)
            {
                return true;
            }

            //Third Row
            if (grid[0, 2] == mark && grid[1, 2] == mark && grid[2, 2] == mark)
            {
                return true;
            }

            //First Column
            if (grid[0, 0] == mark && grid[0, 1] == mark && grid[0, 2] == mark)
            {
                return true;
            }

            //Second Column
            if (grid[1, 0] == mark && grid[1, 1] == mark && grid[1, 2] == mark)
            {
                return true;
            }

            //Third Column
            if (grid[2, 0] == mark && grid[2, 1] == mark && grid[2, 2] == mark)
            {
                return true;
            }

            //Diagnol Left -> Right
            if (grid[0, 0] == mark && grid[1, 1] == mark && grid[2, 2] == mark)
            {
                return true;
            }

            //Diagnol Right -> Left
            if (grid[2, 0] == mark && grid[1, 1] == mark && grid[0, 2] == mark)
            {
                return true;
            }
            return false;
        }

        static bool Stalemate()
        {
            int convertedNumber;

            if (Int32.TryParse(grid[0, 0], out convertedNumber) || Int32.TryParse(grid[1, 0], out convertedNumber) || Int32.TryParse(grid[2, 0], out convertedNumber) ||
                Int32.TryParse(grid[0, 1], out convertedNumber) || Int32.TryParse(grid[1, 1], out convertedNumber) || Int32.TryParse(grid[2, 1], out convertedNumber) ||
                Int32.TryParse(grid[0, 2], out convertedNumber) || Int32.TryParse(grid[1, 2], out convertedNumber) || Int32.TryParse(grid[2, 2], out convertedNumber))
            {
                return false;
            }

            return true;
        }

        static int EasyComputerPick()
        {
            Random rnd = new Random();
            int p = rnd.Next(1, 10);
            return p;
        }

        static void PlayGame()
        {
            Console.WriteLine("");
            Console.WriteLine("");

            //Creates/Restarts grid
            CreateGrid();

            //Selects a player
            PlayerSelector();

            while (true)
            {
                PrintGrid();

                PlayerTurn();

                if (WinCondition())
                {
                    Console.WriteLine("");
                    PrintGrid();
                    Console.WriteLine("");
                    Console.WriteLine(currentPlayer + " has won!");
                    break;
                }
                else if (Stalemate())
                {
                    Console.WriteLine("");
                    PrintGrid();
                    Console.WriteLine("");
                    Console.WriteLine("A stalemate has occured.");
                    break;
                }

                if (currentPlayer == "X") //Swtiches players.
                {
                    currentPlayer = "O";
                }
                else
                {
                    currentPlayer = "X";
                }
            }
        }

        static void EasyComputerTurn()
        {
            Console.WriteLine("");
            Console.WriteLine("O's turn.");
            while (true)
            {
                int i = EasyComputerPick();
                if (PlaceMark(currentPlayer, i))
                {
                    return;
                }
            }
        }

        static void PlayEasyComputer()
        {
            Console.WriteLine("");
            Console.WriteLine("");

            PlayerSelector();
            CreateGrid();

            while (true)
            {
                PrintGrid();

                if (currentPlayer == "X")
                {
                    PlayerTurn();
                }

                else
                {
                    EasyComputerTurn();
                }

                if (WinCondition())
                {
                    Console.WriteLine("");
                    PrintGrid();
                    Console.WriteLine("");
                    Console.WriteLine(currentPlayer + " has won!");
                    break;
                }
                else if (Stalemate())
                {
                    Console.WriteLine("");
                    PrintGrid();
                    Console.WriteLine("");
                    Console.WriteLine("A stalemate has occured.");
                    break;
                }

                if (currentPlayer == "X") //Swtiches players.
                {
                    currentPlayer = "O";
                }
                else
                {
                    currentPlayer = "X";
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("Hello and welcome to Tic Tac Toe made by professionals. Honestly.");

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("To play versus another human, please press 1.");
                Console.WriteLine("To play versus an easy computer, please press 2.");
                Console.WriteLine("To quit, please press Esc.");
                Console.WriteLine("");
                ConsoleKeyInfo Input = Console.ReadKey();

                if (Input.Key == ConsoleKey.D1)
                {
                    PlayGame();
                    Console.WriteLine("");
                    Console.WriteLine("");
                }

                else if (Input.Key == ConsoleKey.D2)
                {
                    PlayEasyComputer();
                    Console.WriteLine("");
                    Console.WriteLine("");
                }

                else if (Input.Key == ConsoleKey.Escape)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid selection, please try again.");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Thank you for playing Tic Tac Toe.");
            Console.WriteLine("Prease any key to quit.");
            Console.ReadKey();
        }
    }
    //Construct "Hard Mode" here, then cut/paste up.



}   

/*Building an intelligent AI -> 
1st Priority go for win in 1 turn 
2nd -> Block Player from winning 
3rd -> Fork - Create an opportunity you can win in 2 ways.
4th -> Block opponent's fork.
    1)  Create two in a row to force the opponent into defending. As long as it doesn't result in them creating a fork or women.
        I.E. if X has a corner, O has center, X has opposite corner. O must NOT play a corner in order to win/stalemate (Playing a corner in this scenario creates a fork for X to win).
    2) If there is a configuration where the opponent can fork, block that fork.
5th -> Play the center (she don't know)
6th -> Play Opposite corner
    If the opponent is in a corner, play the opposite corner.
7th -> Play Empty corner (play an empty corner)
8th -> Play an empty side

Diagnoal points (1,3,7,9)
cardinal points (2,4,6,8)

    center (5) has 4 potential win conditions, corners have 3 (1,3,7,9)
*/
