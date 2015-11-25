using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Grid
    {
        private string[,] gridstate;

        public Grid(Grid otherGrid) //Completely different because of the arguements. Consturctor Overload
        {
            this.gridstate = otherGrid.InternalGridState;
        }

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

        public string[,] InternalGridState
        {
            get
            {
                return gridstate;
            }
        }

        public string GetAtPosition(int p)
        {
            switch (p)
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
                return gridstate[x, y];
            }
            set
            {
                gridstate[x, y] = value;
            }
        }

        public int CanWin(string mark)
        {
            //Rows

            if (this.GetAtPosition(1).Contains(mark) && this.GetAtPosition(2).Contains(mark)) { return 3; }

            if (this.GetAtPosition(2).Contains(mark) && this.GetAtPosition(3).Contains(mark)) { return 1; }

            if (this.GetAtPosition(1).Contains(mark) && this.GetAtPosition(3).Contains(mark)) { return 2; }

            if (this.GetAtPosition(4).Contains(mark) && this.GetAtPosition(5).Contains(mark)) { return 6; }

            if (this.GetAtPosition(5).Contains(mark) && this.GetAtPosition(6).Contains(mark)) { return 4; }

            if (this.GetAtPosition(4).Contains(mark) && this.GetAtPosition(6).Contains(mark)) { return 5; }

            if (this.GetAtPosition(7).Contains(mark) && this.GetAtPosition(8).Contains(mark)) { return 9; }

            if (this.GetAtPosition(8).Contains(mark) && this.GetAtPosition(9).Contains(mark)) { return 7; }

            if (this.GetAtPosition(7).Contains(mark) && this.GetAtPosition(9).Contains(mark)) { return 8; }

            //Colums

            if (this.GetAtPosition(1).Contains(mark) && this.GetAtPosition(4).Contains(mark)) { return 7; }

            if (this.GetAtPosition(4).Contains(mark) && this.GetAtPosition(7).Contains(mark)) { return 1; }

            if (this.GetAtPosition(1).Contains(mark) && this.GetAtPosition(7).Contains(mark)) { return 4; }

            if (this.GetAtPosition(2).Contains(mark) && this.GetAtPosition(5).Contains(mark)) { return 8; }

            if (this.GetAtPosition(5).Contains(mark) && this.GetAtPosition(8).Contains(mark)) { return 2; }

            if (this.GetAtPosition(2).Contains(mark) && this.GetAtPosition(8).Contains(mark)) { return 5; }

            if (this.GetAtPosition(3).Contains(mark) && this.GetAtPosition(6).Contains(mark)) { return 9; }

            if (this.GetAtPosition(6).Contains(mark) && this.GetAtPosition(9).Contains(mark)) { return 3; }

            if (this.GetAtPosition(3).Contains(mark) && this.GetAtPosition(9).Contains(mark)) { return 6; }

            //Diagonals
            if (this.GetAtPosition(1).Contains(mark) && this.GetAtPosition(5).Contains(mark)) { return 9; }

            if (this.GetAtPosition(5).Contains(mark) && this.GetAtPosition(9).Contains(mark)) { return 1; }

            if (this.GetAtPosition(1).Contains(mark) && this.GetAtPosition(9).Contains(mark)) { return 5; }

            if (this.GetAtPosition(3).Contains(mark) && this.GetAtPosition(5).Contains(mark)) { return 7; }

            if (this.GetAtPosition(5).Contains(mark) && this.GetAtPosition(7).Contains(mark)) { return 3; }

            if (this.GetAtPosition(3).Contains(mark) && this.GetAtPosition(7).Contains(mark)) { return 5; }

            return -1;
        }

        public Dictionary<int, int> PossibleTwoInARow(string mark) //Gives an error
        {
            // List<int> possibleSlots = new List<int>(); //Camel Case is helloMyMaster use for when you're saving to the stack (variables)

            // int[] slots = new int[9];

            Dictionary<int, int> slots = new Dictionary<int, int>();

            for (int i = 1; i < 10; i++) //i is a position on a grid, this takes each time a slot could be filled and adds 1 to that specific slot counter

            {
                slots[i] = 0;
            }

            if (this.GetAtPosition(1).Contains(mark))
            {
                slots[2]++;
                slots[4]++;
                slots[5]++;
            }

            if (this.GetAtPosition(2).Contains(mark))
            {
                slots[1]++;
                slots[3]++;
                slots[5]++;
            }

            if (this.GetAtPosition(3).Contains(mark))
            {
                slots[2]++;
                slots[4]++;
                slots[6]++;
            }

            if (this.GetAtPosition(4).Contains(mark))
            {
                slots[1]++;
                slots[5]++;
                slots[7]++;
            }

            if (this.GetAtPosition(5).Contains(mark))
            {
                slots[1]++;
                slots[2]++;
                slots[3]++;
                slots[4]++;
                slots[6]++;
                slots[7]++;
                slots[8]++;
                slots[9]++;
            }

            if (this.GetAtPosition(6).Contains(mark))
            {
                slots[3]++;
                slots[5]++;
                slots[9]++;
            }

            if (this.GetAtPosition(7).Contains(mark))
            {
                slots[4]++;
                slots[5]++;
                slots[8]++;
            }

            if (this.GetAtPosition(8).Contains(mark))
            {
                slots[5]++;
                slots[7]++;
                slots[9]++;
            }

            if (this.GetAtPosition(9).Contains(mark))
            {
                slots[5]++;
                slots[6]++;
                slots[8]++;
            }

            return slots;
        }

    }
}
