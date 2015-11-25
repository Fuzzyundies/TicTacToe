using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe 
{

    class Program
    {
        static Grid playGrid;

        static string currentPlayer;

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

        static void CreateGrid() //Initializer function
        {
            playGrid = new Grid();
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
        
        static bool SimulationFork(int i, Grid simGrid)
        {
            Place a mark

            marks i;

            runs canfork;

            returns bool (if it results in a fork or not)
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
