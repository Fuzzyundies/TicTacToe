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
    _[0],[0]_|_[1],[0]_|_[2],[0]_
    _4_|_5_|_6_
    _7_|_8_|_9_

*/

/*
    2 Dimensional Array
*/
{
    class Grid
    {
        private string[,] gridstate;

        public Grid()
        {
            
            gridstate = new string[3, 3];
            gridstate[0, 0] = "1";
            gridstate[1, 0] = "2";
            gridstate[2, 0] = "3";
            gridstate[0, 1] = "4";
            gridstate[1, 1] = "5";
            gridstate[2, 1] = "6";
            gridstate[0, 2] = "7";
            gridstate[1, 2] = "8";
            gridstate[2, 2] = "9";
            
        }

        public string GetAtPosition(int p)
        {
            switch(p)
            {
                case 1:
                    return gridstate[0, 0];
                    break;

                case 2:
                    return gridstate[1, 0];
                    break;

                case 3:
                    return gridstate[2, 0];
                    break;

                case 4:
                    return gridstate[0, 1];
                    break;

                case 5:
                    return gridstate[1, 1];
                    break;

                case 6:
                    return gridstate[2, 1];
                    break;

                case 7:
                    return gridstate[0, 2];
                    break;

                case 8:
                    return gridstate[1, 2];
                    break;

                case 9:
                    return gridstate[2, 2];
                    break;

                default:
                    throw new ArgumentException("Position " + p + " does not exist.");
                    break;
            }
        }

        public string this[int x, int y]
        {
            get
            {
                return gridstate [x,y];
            }
            set
            {
                gridstate[x, y] = value;
            }
        }

    }

    class Program
    {
        static Grid playGrid;

        static string currentPlayer;

        static void PrintSlot(int x, int y)
        {
            if (playGrid[x, y] == "X")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (playGrid[x, y] == "O")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(playGrid[x, y]);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintGrid() //Error
        {
            string output = string.Format("_{0}_|_{1}_|_{2}_\n_{3}_|_{4}_|_{5}_\n {6} | {7} | {8} ", playGrid[0, 0], playGrid[1, 0], playGrid[2, 0],
                playGrid[0, 1], playGrid[1, 1], playGrid[2, 1], playGrid[0, 2], playGrid[1, 2], playGrid[2, 2]); // { } is a Token

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
            playGrid = new Grid();
        }

        static bool PlaceMark(string mark, int slot) //Does this write X,O in the slot, can't read that it does.
        {

            switch (slot) //Defines cases. Cleaner way of writing "ifs"
            {
                case 1:
                    if (playGrid[0, 0].Contains("1"))
                    {
                        playGrid[0, 0] = mark;
                        return true;
                    }
                    break;

                case 2:
                    if (playGrid[1, 0].Contains("2"))
                    {
                        playGrid[1, 0] = mark;
                        return true;
                    }
                    break;

                case 3:
                    if (playGrid[2, 0].Contains("3"))
                    {
                        playGrid[2, 0] = mark;
                        return true;
                    }
                    break;

                case 4:
                    if (playGrid[0, 1].Contains("4"))
                    {
                        playGrid[0, 1] = mark;
                        return true;
                    }
                    break;

                case 5:
                    if (playGrid[1, 1].Contains("5"))
                    {
                        playGrid[1, 1] = mark;
                        return true;
                    }
                    break;

                case 6:
                    if (playGrid[2, 1].Contains("6"))
                    {
                        playGrid[2, 1] = mark;
                        return true;
                    }
                    break;

                case 7:
                    if (playGrid[0, 2].Contains("7"))
                    {
                        playGrid[0, 2] = mark;
                        return true;
                    }
                    break;


                case 8:
                    if (playGrid[1, 2].Contains("8"))
                    {
                        playGrid[1, 2] = mark;
                        return true;
                    }
                    break;

                case 9:
                    if (playGrid[2, 2].Contains("9"))
                    {
                        playGrid[2, 2] = mark;
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
            if (playGrid[0, 0] == mark && playGrid[1, 0] == mark && playGrid[2, 0] == mark)
            {
                return true;
            }

            //Second Row
            if (playGrid[0, 1] == mark && playGrid[1, 1] == mark && playGrid[2, 1] == mark)
            {
                return true;
            }

            //Third Row
            if (playGrid[0, 2] == mark && playGrid[1, 2] == mark && playGrid[2, 2] == mark)
            {
                return true;
            }

            //First Column
            if (playGrid[0, 0] == mark && playGrid[0, 1] == mark && playGrid[0, 2] == mark)
            {
                return true;
            }

            //Second Column
            if (playGrid[1, 0] == mark && playGrid[1, 1] == mark && playGrid[1, 2] == mark)
            {
                return true;
            }

            //Third Column
            if (playGrid[2, 0] == mark && playGrid[2, 1] == mark && playGrid[2, 2] == mark)
            {
                return true;
            }

            //Diagonal Left -> Right
            if (playGrid[0, 0] == mark && playGrid[1, 1] == mark && playGrid[2, 2] == mark)
            {
                return true;
            }

            //Diagonal Right -> Left
            if (playGrid[2, 0] == mark && playGrid[1, 1] == mark && playGrid[0, 2] == mark)
            {
                return true;
            }
            return false;
        }

        static bool Stalemate()
        {
            int convertedNumber;

            if (Int32.TryParse(playGrid[0, 0], out convertedNumber) || Int32.TryParse(playGrid[1, 0], out convertedNumber) || Int32.TryParse(playGrid[2, 0], out convertedNumber) ||
                Int32.TryParse(playGrid[0, 1], out convertedNumber) || Int32.TryParse(playGrid[1, 1], out convertedNumber) || Int32.TryParse(playGrid[2, 1], out convertedNumber) ||
                Int32.TryParse(playGrid[0, 2], out convertedNumber) || Int32.TryParse(playGrid[1, 2], out convertedNumber) || Int32.TryParse(playGrid[2, 2], out convertedNumber))
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

        //Construct "Hard Mode" here, then cut/paste up.
        static int CanWin(string mark, Grid currentGrid)
        {
            //Rows

            if (currentGrid.GetAtPosition(1).Contains(mark) && currentGrid.GetAtPosition(2).Contains(mark)) {return 3;}

            if (currentGrid.GetAtPosition(2).Contains(mark) && currentGrid.GetAtPosition(3).Contains(mark)) {return 1;}

            if (currentGrid.GetAtPosition(1).Contains(mark) && currentGrid.GetAtPosition(3).Contains(mark)) {return 2;}

            if (currentGrid.GetAtPosition(4).Contains(mark) && currentGrid.GetAtPosition(5).Contains(mark)) {return 6;}

            if (currentGrid.GetAtPosition(5).Contains(mark) && currentGrid.GetAtPosition(6).Contains(mark)) {return 4;}

            if (currentGrid.GetAtPosition(4).Contains(mark) && currentGrid.GetAtPosition(6).Contains(mark)) {return 5;}

            if (currentGrid.GetAtPosition(7).Contains(mark) && currentGrid.GetAtPosition(8).Contains(mark)) {return 9;}

            if (currentGrid.GetAtPosition(8).Contains(mark) && currentGrid.GetAtPosition(9).Contains(mark)) {return 7;}

            if (currentGrid.GetAtPosition(7).Contains(mark) && currentGrid.GetAtPosition(9).Contains(mark)) {return 8;}

            //Colums

            if (currentGrid.GetAtPosition(1).Contains(mark) && currentGrid.GetAtPosition(4).Contains(mark)) { return 7; }

            if (currentGrid.GetAtPosition(4).Contains(mark) && currentGrid.GetAtPosition(7).Contains(mark)) { return 1; }

            if (currentGrid.GetAtPosition(1).Contains(mark) && currentGrid.GetAtPosition(7).Contains(mark)) { return 4; }

            if (currentGrid.GetAtPosition(2).Contains(mark) && currentGrid.GetAtPosition(5).Contains(mark)) { return 8; }

            if (currentGrid.GetAtPosition(5).Contains(mark) && currentGrid.GetAtPosition(8).Contains(mark)) { return 2; }

            if (currentGrid.GetAtPosition(2).Contains(mark) && currentGrid.GetAtPosition(8).Contains(mark)) { return 5; }

            if (currentGrid.GetAtPosition(3).Contains(mark) && currentGrid.GetAtPosition(6).Contains(mark)) { return 9; }

            if (currentGrid.GetAtPosition(6).Contains(mark) && currentGrid.GetAtPosition(9).Contains(mark)) { return 3; }

            if (currentGrid.GetAtPosition(3).Contains(mark) && currentGrid.GetAtPosition(9).Contains(mark)) { return 6; }

            //Diagonals
            if (currentGrid.GetAtPosition(1).Contains(mark) && currentGrid.GetAtPosition(5).Contains(mark)) { return 9; }

            if (currentGrid.GetAtPosition(5).Contains(mark) && currentGrid.GetAtPosition(9).Contains(mark)) { return 1; }

            if (currentGrid.GetAtPosition(1).Contains(mark) && currentGrid.GetAtPosition(9).Contains(mark)) { return 5; }

            if (currentGrid.GetAtPosition(3).Contains(mark) && currentGrid.GetAtPosition(5).Contains(mark)) { return 7; }

            if (currentGrid.GetAtPosition(5).Contains(mark) && currentGrid.GetAtPosition(7).Contains(mark)) { return 3; }

            if (currentGrid.GetAtPosition(3).Contains(mark) && currentGrid.GetAtPosition(7).Contains(mark)) { return 5; }

            return -1;
        }
        
        static int[] PossibleTwoInARow()
        {
            //returns an Array of numbers
        }

        static int CanForkToWin()
        {
            // Go through all the int statements as above
        }

        static int CanBlockFork()
        {

        }

        static void HardComputerTurn()
        {
            int slotToMark;
            slotToMark = CanWin("O", playGrid); //Check to see if computer can win

            if(slotToMark > 0) // Go for the win
            {
                //Computer marks this slot
            }

            slotToMark = CanWin("X", playGrid); // Check to see if human can win

            if (slotToMark > 0)
            {
                //Computer marks this slot to cock block
            }


        }
    }




    /*
        static void HardComputer1(string mark, int slot) //Does this write X,O in the slot, can't read that it does.
        {

            switch (slot) //Defines cases. Cleaner way of writing "ifs"
            {

                //First Row
                case 1:
                    if (grid[0, 0].Contains(currentPlayer) && grid[1, 0].Contains(currentPlayer))
                    {
                        grid[2, 0] = mark;
                        return;
                    }
                    break;

                case 2:
                    if (grid[1, 0].Contains(currentPlayer) && grid[2, 0].Contains(currentPlayer))
                    {
                        grid[0, 0] = mark;
                        return;
                    }
                    break;

                case 3:
                    if (grid[0, 0].Contains(currentPlayer) && grid[2, 0].Contains(currentPlayer))
                    {
                        grid[1, 0] = mark;
                        return;
                    }
                    break;

                //Second Row
                case 4:
                    if (grid[0, 1].Contains(currentPlayer) && grid[1, 1].Contains(currentPlayer))
                    {
                        grid[2, 1] = mark;
                        return;
                    }
                    break;

                case 5:
                    if (grid[1, 1].Contains(currentPlayer) && grid[2, 1].Contains(currentPlayer))
                    {
                        grid[0, 1] = mark;
                        return;
                    }
                    break;

                case 6:
                    if (grid[0, 1].Contains(currentPlayer) && grid[2, 1].Contains(currentPlayer))
                    {
                        grid[1, 1] = mark;
                        return;
                    }
                    break;

                //Third Row
                case 7:
                    if (grid[0, 2].Contains(currentPlayer) && grid[1, 2].Contains(currentPlayer))
                    {
                        grid[2, 2] = mark;
                        return;
                    }
                    break;

                case 8:
                    if (grid[1, 2].Contains(currentPlayer) && grid[2, 2].Contains(currentPlayer))
                    {
                        grid[0, 2] = mark;
                        return;
                    }
                    break;

                case 9:
                    if (grid[0, 2].Contains(currentPlayer) && grid[2, 2].Contains(currentPlayer))
                    {
                        grid[1, 2] = mark;
                        return;
                    }
                    break;

                //First Column
                case 10:
                    if (grid[0, 0].Contains(currentPlayer) && grid[0, 1].Contains(currentPlayer))
                    {
                        grid[0, 2] = mark;
                        return;
                    }
                    break;

                case 11:
                    if (grid[0, 1].Contains(currentPlayer) && grid[0, 2].Contains(currentPlayer))
                    {
                        grid[0, 0] = mark;
                        return;
                    }
                    break;

                case 12:
                    if (grid[0, 0].Contains(currentPlayer) && grid[0, 2].Contains(currentPlayer))
                    {
                        grid[0, 1] = mark;
                        return;
                    }
                    break;

                //Second Column
                case 13:
                    if (grid[1, 0].Contains(currentPlayer) && grid[1, 1].Contains(currentPlayer))
                    {
                        grid[1, 2] = mark;
                        return;
                    }
                    break;

                case 14:
                    if (grid[1, 1].Contains(currentPlayer) && grid[1, 2].Contains(currentPlayer))
                    {
                        grid[1, 0] = mark;
                        return;
                    }
                    break;

                case 15:
                    if (grid[1, 0].Contains(currentPlayer) && grid[1, 2].Contains(currentPlayer))
                    {
                        grid[1, 1] = mark;
                        return;
                    }
                    break;

                //Third Column
                case 16:
                    if (grid[2, 0].Contains(currentPlayer) && grid[2, 1].Contains(currentPlayer))
                    {
                        grid[2, 2] = mark;
                        return;
                    }
                    break;

                case 17:
                    if (grid[2, 1].Contains(currentPlayer) && grid[2, 2].Contains(currentPlayer))
                    {
                        grid[2, 0] = mark;
                        return;
                    }
                    break;

                case 18:
                    if (grid[2, 0].Contains(currentPlayer) && grid[2, 2].Contains(currentPlayer))
                    {
                        grid[2, 1] = mark;
                        return;
                    }
                    break;

                //Left to Right Diagonal
                case 19:
                    if (grid[0, 0].Contains(currentPlayer) && grid[1, 1].Contains(currentPlayer))
                    {
                        grid[2, 2] = mark;
                        return;
                    }
                    break;

                case 20:
                    if (grid[1, 1].Contains(currentPlayer) && grid[2, 2].Contains(currentPlayer))
                    {
                        grid[0, 0] = mark;
                        return;
                    }
                    break;

                case 21:
                    if (grid[0, 0].Contains(currentPlayer) && grid[2, 2].Contains(currentPlayer))
                    {
                        grid[1, 1] = mark;
                        return;
                    }
                    break;

                //Right to Left Diagonal
                case 22:
                    if (grid[2, 0].Contains(currentPlayer) && grid[1, 1].Contains(currentPlayer))
                    {
                        grid[0, 2] = mark;
                        return;
                    }
                    break;

                case 23:
                    if (grid[1, 1].Contains(currentPlayer) && grid[0, 2].Contains(currentPlayer))
                    {
                        grid[2, 0] = mark;
                        return;
                    }
                    break;

                case 24:
                    if (grid[0, 2].Contains(currentPlayer) && grid[2, 0].Contains(currentPlayer))
                    {
                        grid[1, 1] = mark;
                        return;
                    }
                    break;

                default: //If you reach me, then do next:
                    break;
            }
        }

        static void HardComputer2(string mark, int slot) //Does this write X,O in the slot, can't read that it does.
        {

            switch (slot) //Defines cases. Cleaner way of writing "ifs"
            {

                //First Row
                case 1:
                    if (grid[0, 0].Contains("X") && grid[1, 0].Contains("X"))
                    {
                        grid[2, 0] = mark;
                        return;
                    }
                    break;

                case 2:
                    if (grid[1, 0].Contains("X") && grid[2, 0].Contains("X"))
                    {
                        grid[0, 0] = mark;
                        return;
                    }
                    break;

                case 3:
                    if (grid[0, 0].Contains("X") && grid[2, 0].Contains("X"))
                    {
                        grid[1, 0] = mark;
                        return;
                    }
                    break;

                //Second Row
                case 4:
                    if (grid[0, 1].Contains("X") && grid[1, 1].Contains("X"))
                    {
                        grid[2, 1] = mark;
                        return;
                    }
                    break;

                case 5:
                    if (grid[1, 1].Contains("X") && grid[2, 1].Contains("X"))
                    {
                        grid[0, 1] = mark;
                        return;
                    }
                    break;

                case 6:
                    if (grid[0, 1].Contains("X") && grid[2, 1].Contains("X"))
                    {
                        grid[1, 1] = mark;
                        return;
                    }
                    break;

                //Third Row
                case 7:
                    if (grid[0, 2].Contains("X") && grid[1, 2].Contains("X"))
                    {
                        grid[2, 2] = mark;
                        return;
                    }
                    break;

                case 8:
                    if (grid[1, 2].Contains("X") && grid[2, 2].Contains("X"))
                    {
                        grid[0, 2] = mark;
                        return;
                    }
                    break;

                case 9:
                    if (grid[0, 2].Contains("X") && grid[2, 2].Contains("X"))
                    {
                        grid[1, 2] = mark;
                        return;
                    }
                    break;

                //First Column
                case 10:
                    if (grid[0, 0].Contains("X") && grid[0, 1].Contains("X"))
                    {
                        grid[0, 2] = mark;
                        return;
                    }
                    break;

                case 11:
                    if (grid[0, 1].Contains("X") && grid[0, 2].Contains("X"))
                    {
                        grid[0, 0] = mark;
                        return;
                    }
                    break;

                case 12:
                    if (grid[0, 0].Contains("X") && grid[0, 2].Contains("X"))
                    {
                        grid[0, 1] = mark;
                        return;
                    }
                    break;

                //Second Column
                case 13:
                    if (grid[1, 0].Contains("X") && grid[1, 1].Contains("X"))
                    {
                        grid[1, 2] = mark;
                        return;
                    }
                    break;

                case 14:
                    if (grid[1, 1].Contains("X") && grid[1, 2].Contains("X"))
                    {
                        grid[1, 0] = mark;
                        return;
                    }
                    break;

                case 15:
                    if (grid[1, 0].Contains("X") && grid[1, 2].Contains("X"))
                    {
                        grid[1, 1] = mark;
                        return;
                    }
                    break;

                //Third Column
                case 16:
                    if (grid[2, 0].Contains("X") && grid[2, 1].Contains("X"))
                    {
                        grid[2, 2] = mark;
                        return;
                    }
                    break;

                case 17:
                    if (grid[2, 1].Contains("X") && grid[2, 2].Contains("X"))
                    {
                        grid[2, 0] = mark;
                        return;
                    }
                    break;

                case 18:
                    if (grid[2, 0].Contains("X") && grid[2, 2].Contains("X"))
                    {
                        grid[2, 1] = mark;
                        return;
                    }
                    break;

                //Left to Right Diagonal
                case 19:
                    if (grid[0, 0].Contains("X") && grid[1, 1].Contains("X"))
                    {
                        grid[2, 2] = mark;
                        return;
                    }
                    break;

                case 20:
                    if (grid[1, 1].Contains("X") && grid[2, 2].Contains("X"))
                    {
                        grid[0, 0] = mark;
                        return;
                    }
                    break;

                case 21:
                    if (grid[0, 0].Contains("X") && grid[2, 2].Contains("X"))
                    {
                        grid[1, 1] = mark;
                        return;
                    }
                    break;

                //Right to Left Diagonal
                case 22:
                    if (grid[2, 0].Contains("X") && grid[1, 1].Contains("X"))
                    {
                        grid[0, 2] = mark;
                        return;
                    }
                    break;

                case 23:
                    if (grid[1, 1].Contains("X") && grid[0, 2].Contains("X"))
                    {
                        grid[2, 0] = mark;
                        return;
                    }
                    break;

                case 24:
                    if (grid[0, 2].Contains("X") && grid[2, 0].Contains("X"))
                    {
                        grid[1, 1] = mark;
                        return;
                    }
                    break;

                default: //If you reach me, then do next:
                    break;
            }
        }

        */

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
